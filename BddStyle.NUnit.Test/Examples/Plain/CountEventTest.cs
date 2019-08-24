using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.Examples.Plain
{
    [TestFixture]
    public class CountEventTest
    {
        private const int ThreadCount = 100;
        private EventCount _sut;

        private Task[] StartIncreases()
        {
            return Enumerable.Range(0, ThreadCount).Select(
                i => Task.Factory.StartNew(_sut.Increase)).ToArray();
        }

        private Task[] StartDecreases()
        {
            return Enumerable.Range(0, ThreadCount).Select(
                i => Task.Factory.StartNew(_sut.Decrease)).ToArray();
        }

        protected T Timed<T>(TimeSpan frame, Func<T> action)
        {
            T result = default(T);
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
        public void CountEvent_AddingThenDecreasing_CountIs0()
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
        public void CountEvent_ChangingInParallel_WaitIsSuccessful()
        {

        }





        [Test]
        public void CountEvent_AddingAndDecreasingOftenOnAlreadyIncreased_ReturnsFalseByTimeout()
        {
            //Arrange
            _sut.Increase();

        }
    }
}