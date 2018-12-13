using System;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.given_phone_created
{
    public class when_calling : Context
    {
        protected override void Act()
        {
            Sut.Call(TestPhoneNumber);
        }

        [Test]
        public void then_last_called_phone_number_is_set()
        {
            Sut.LastCalled.Should().NotBeNull().And.Be(TestPhoneNumber);
        }

        [Test]
        public void then_call_failed()
        {
            Sut.LastCallSucceeded.Should().BeFalse();
        }

        [Test]
        public void then_using_empty_phone_number_fails()
        {
            Sut.Invoking(_ => _.Call(null))
                .Should().Throw<Exception>();
        }
    }
}