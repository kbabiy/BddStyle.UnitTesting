using System;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.Examples.given_EventCount.and_increased_once
{
    public class when_waiting_for_0 : Context
    {
        [Test]
        public void then_fail_returned()
        {
            Sut.WaitUntil(0, TimeSpan.FromMilliseconds(100)).Should().BeFalse();
        }
    }
}