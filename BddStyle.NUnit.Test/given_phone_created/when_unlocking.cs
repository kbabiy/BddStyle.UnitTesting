using System;
using System.Collections.Generic;
using FluentAssertions;
using JetBrains.Annotations;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.given_phone_created
{
    public class when_unlocking : Context
    {
        protected override bool SuppressAct => true;

        [UsedImplicitly]
        public static readonly IEnumerable<TestCaseData> ValidPins = new[]
        {
            new TestCaseData(TestPin).Returns(true).SetName("then phone pin accepted"),
            new TestCaseData(Phone.ServicePin).Returns(true).SetName("then service pin accepted"),
            new TestCaseData("wrong").Returns(false).SetName("then wrong pin not accepted"),
        };

        [TestCaseSource(nameof(ValidPins))]
        public bool then_valid_pin_succeed(string inputPin)
        {
            return Sut.Unlock(inputPin);
        }

        [Test]
        public void then_null_pin_fails()
        {
            Sut.Invoking(_ => _.Unlock(null))
                .Should().Throw<ArgumentNullException>();
        }
    }
}