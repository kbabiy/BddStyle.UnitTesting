using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.given_phone_created
{
    public class when_unlocking : Context
    {
        protected override bool SuppressAct => true;

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData(Phone.ServicePin).Returns(true).SetName("service pin accepted");
                yield return new TestCaseData("wrong").Returns(false).SetName("wrong pin not accepted");
                yield return new TestCaseData(null).Throws(typeof(ArgumentNullException)).SetName("null pin throws exception");
            }
        }

        [TestCaseSource(nameof(TestCases))]
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