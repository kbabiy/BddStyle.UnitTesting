using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.given_phone_created
{
    public class when_unlocking : Context
    {
        protected override bool SuppressAct => true;

        private static readonly IEnumerable<TestCaseData> Cases = new[]
        {
            new TestCaseData(Phone.ServicePin).Returns(true).SetName("service pin accepted"),
            new TestCaseData("wrong").Returns(false).SetName("wrong pin not accepted"),
            new TestCaseData(null).Throws(typeof(ArgumentNullException)).SetName("null pin throws exception")
        };

        [TestCaseSource(nameof(Cases))]
        public bool then(string inputPin)
        {
            return Sut.Unlock(inputPin);
        }

        [Test]
        public void then_phone_pin_accepted()
        {
            Sut.Unlock(TestPin).Should().BeTrue();
        }
    }
}