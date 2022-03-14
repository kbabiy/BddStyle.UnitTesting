﻿using System;
using System.Diagnostics;
using System.Threading;

namespace BddStyle.NUnit.Test.Examples;

/// <summary>
/// Registers Increase and Decrease call counts and allows waiting the count to reach 0 
/// </summary>
public class EventCount
{
    private readonly object _counterChangeLock = new();
    private int _counter;

    public int Count => Thread.VolatileRead(ref _counter);

    public void Increase()
    {
        lock (_counterChangeLock)
        {
            _counter++;
            Monitor.Pulse(_counterChangeLock);
        }
    }

    public void Decrease()
    {
        lock (_counterChangeLock)
        {
            _counter--;
            Monitor.Pulse(_counterChangeLock);
        }
    }

    public bool WaitUntil(int targetValue, TimeSpan howLong)
    {
        //Monitor.Wait doesn't support interval higher than int.MaxValue
        var checkInterval = howLong.TotalMilliseconds <= 0 ? 0
            : howLong.TotalMilliseconds > int.MaxValue ? int.MaxValue
            : (int) howLong.TotalMilliseconds / 20;

        var sw = Stopwatch.StartNew();
        lock (_counterChangeLock)
        {
            while (_counter > targetValue && sw.Elapsed < howLong)
            {
                Monitor.Wait(_counterChangeLock, checkInterval);
            }

            return _counter <= targetValue;
        }
    }
}