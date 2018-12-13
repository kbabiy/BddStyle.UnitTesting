using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.given_phone_created.and_unlocked
{
    public class when_calling_empty : Context
    {
        protected override bool SuppressAct => true;

        private static readonly IEnumerable<TestCaseData> Cases = new[]
        {
            new TestCaseData(null).SetName("passing null"),
            new TestCaseData(null).SetName("passing empty string")
        };

        [TestCaseSource(nameof(Cases))]
        public void then_failure(string emptyPhone)
        {
            Sut.Invoking(_ => _.Call(emptyPhone)).Should().Throw<ArgumentException>();
        }
    }
}