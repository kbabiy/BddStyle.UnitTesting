using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.Examples.given_EventCount
{

    public class when_adding_then_decreasing : Context
    {
        private int _countAfterAdding;
        private bool _decreaseWaitSuccess;

        protected override void Act()
        {
            var increases = StartIncreases();
            Task.WaitAll(increases, TimeSpan.FromSeconds(10));
            _countAfterAdding = Sut.Count;

            StartDecreases();

            _decreaseWaitSuccess = Sut.WaitUntil(0, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void then_added_all()
        {
            _countAfterAdding.Should().Be(ThreadCount);
        }

        [Test]
        public void then_waited_for_decrease_successfully()
        {
            _decreaseWaitSuccess.Should().BeTrue();
        }

        [Test]
        public void then_after_decrease_count_is_zero()
        {
            Sut.Count.Should().Be(0);
        }
    }
}