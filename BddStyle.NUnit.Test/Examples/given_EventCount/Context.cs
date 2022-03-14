using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;

namespace BddStyle.NUnit.Test.Examples.given_EventCount;

public abstract class Context : ContextBase
{
    protected const int ThreadCount = 100;
    protected EventCount Sut;

    protected override void Arrange()
    {
        Sut = new EventCount();
    }

    protected Task[] StartIncreases()
    {
        return Enumerable.Range(0, ThreadCount).Select(
            _ => Task.Factory.StartNew(Sut.Increase)).ToArray();
    }

    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    protected Task[] StartDecreases()
    {
        return Enumerable.Range(0, ThreadCount).Select(
            _ => Task.Factory.StartNew(Sut.Decrease)).ToArray();
    }

    protected static T Timed<T>(TimeSpan frame, Func<T> action)
    {
        var result = default(T);
        var inTime = Task.Factory.StartNew(() => { return result = action(); }).Wait(frame);

        inTime.Should().BeTrue("Operation is expected to finish within the time frame");

        return result;
    }
}