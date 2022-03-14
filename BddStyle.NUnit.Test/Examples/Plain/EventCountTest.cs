using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.Examples.Plain
{
    [TestFixture]
    public class EventCountTest
    {
        private const int ThreadCount = 100;
        private EventCount _sut;

        private Task[] StartIncreases()
        {
            return Enumerable.Range(0, ThreadCount).Select(
                _ => Task.Factory.StartNew(_sut.Increase)).ToArray();
        }

        [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Local")]
        private Task[] StartDecreases()
        {
            return Enumerable.Range(0, ThreadCount).Select(
                _ => Task.Factory.StartNew(_sut.Decrease)).ToArray();
        }

        private static T Timed<T>(TimeSpan frame, Func<T> action)
        {
            var result = default(T);
            var inTime = Task.Factory.StartNew(() => { return result = action(); }).Wait(frame);

            inTime.Should().BeTrue("Operation is expected to finish within the time frame");

            return result;
        }

        [SetUp]
        public void Setup()
        {
            _sut = new EventCount();
        }

        [Test]
        public void EventCount_AddingThenDecreasing_AllAreAddedThenWaitedForDecreaseAndCountIs0()
        {
            //Arrange
            var increases = StartIncreases();
            Task.WaitAll(increases, TimeSpan.FromSeconds(10));
            var countAfterAdding = _sut.Count;
            StartDecreases();

            //Act
            var decreaseWaitSuccess = _sut.WaitUntil(0, TimeSpan.FromSeconds(10));

            //Assert
            countAfterAdding.Should().Be(ThreadCount);
            decreaseWaitSuccess.Should().BeTrue();
            _sut.Count.Should().Be(0);
        }

        [Test]
        public void EventCount_ChangingInParallel_WaitIsSuccessful()
        {
            //Arrange
            StartIncreases();
            Thread.Sleep(100);
            StartDecreases();

            //Act-Assert
            _sut.WaitUntil(0, TimeSpan.FromSeconds(10)).Should().BeTrue();
        }


        [Test]
        public void EventCount_DecreasingBelowZero_ReturnsSuccess()
        {
            //Arrange
            _sut.Decrease();

            //Act-Assert
            _sut.WaitUntil(0, TimeSpan.FromSeconds(1)).Should().BeTrue();
        }

        [Test]
        public void EventCount_Unchanged_WaitingReturnsSuccessImmediately()
        {
            //Act-Assert
            Timed(TimeSpan.FromMilliseconds(100),
                    () => _sut.WaitUntil(0, TimeSpan.FromSeconds(10)))
                .Should().BeTrue();
        }

        [Test]
        [SuppressMessage("ReSharper", "FunctionNeverReturns")]
        public void CountEvent_AddingAndDecreasingOftenOnIncreased_ReturnsFalseByTimeout()
        {
            //Arrange
            _sut.Increase();

            //Act
            Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        _sut.Increase();
                        Thread.Sleep(100);
                        _sut.Decrease();
                    }
                }
            );

            //Assert
            Timed(TimeSpan.FromSeconds(3),
                    () => _sut.WaitUntil(0, TimeSpan.FromSeconds(1)))
                .Should().BeFalse();
        }

        [Test]
        public void CountEvent_InALongWaitOnIncreased_NextIncreaseAndDecreaseAreNotBlocked()
        {
            //Arrange
            _sut.Increase();

            //Act
            Task.Factory.StartNew(() => _sut.WaitUntil(0, TimeSpan.FromMinutes(1)));
            Thread.Sleep(100);

            //Assert
            _sut.Increase();
            _sut.Decrease();
        }

        [Test]
        public void CountEvent_WaitingOnIncreased_Fails()
        {
            //Arrange
            _sut.Increase();

            //Act
            _sut.WaitUntil(0, TimeSpan.FromMilliseconds(100)).Should().BeFalse();
        }
    }
}