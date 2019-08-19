using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.Examples
{
    [TestFixture]
    public class CountEventTest
    {
        private const int ThreadCount = 100;
        private CountEvent Sut;

        [SetUp]
        public void Setup()
        {
            Sut = new CountEvent();
        }

        private Task[] StartIncreases()
        {
            return Enumerable.Range(0, ThreadCount).Select(
                i => Task.Factory.StartNew(Sut.Increase)).ToArray();
        }

        private Task[] StartDecreases()
        {
            return Enumerable.Range(0, ThreadCount).Select(
                i => Task.Factory.StartNew(Sut.Decrease)).ToArray();
        }

        protected T Timed<T>(TimeSpan frame, Func<T> action)
        {
            T result = default(T);
            var inTime = Task.Factory.StartNew(() => { return result = action(); }).Wait(frame);

            inTime.Should().BeTrue("Operation is expected to finish within the time frame");

            return result;
        }

        [Test]
        public void CountEvent_AddingThenDecreasing_CountIs0()
        {
            //Arrange
            var increases = StartIncreases();
            Task.WaitAll(increases, TimeSpan.FromSeconds(10));
            var countAfterAdding = Sut.Count;
            StartDecreases();

            //Act
            var decreaseWaitSuccess = Sut.WaitUntil(0, TimeSpan.FromSeconds(10));

            //Assert
            countAfterAdding.Should().Be(ThreadCount);
            decreaseWaitSuccess.Should().BeTrue();
            Sut.Count.Should().Be(0);
        }
    }
}