using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.Examples.given_phone_created.and_unlocked
{

    public class when_calling_empty : Context
    {
        protected override bool SuppressAct => true;

        private static readonly IEnumerable<TestCaseData> EmptyPhones = new[]
        {
            new TestCaseData(null).SetName("then passing null fails"),
            new TestCaseData(string.Empty).SetName("then passing empty string fails")
        };

        [TestCaseSource(nameof(EmptyPhones))]
        public void then_empty_phone_fails_call(string phoneNumber)
        {
            Sut.Invoking(_ => _.Call(phoneNumber)).Should().Throw<ArgumentException>();
        }
    }
}