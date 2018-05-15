using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.given_phone_created.and_unlocked
{
    public class when_calling : Context
    {
        public override void Act()
        {
            Sut.Call(TestPhoneNumber);
        }

        [Test]
        public void then_call_succeeded()
        {
            Sut.LastCallSucceeded.Should().BeTrue();
        }
    }
}