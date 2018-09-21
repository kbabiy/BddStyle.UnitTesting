using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.given_phone_created.and_unlocked
{
    public class when_calling_empty : Context
    {
        protected override bool SuppressAct => true;

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private static IEnumerable<TestCaseData> Cases
        {
            get
            {
                yield return new TestCaseData(null).SetName("passing null");
                yield return new TestCaseData(null).SetName("passing empty string");
            }
        }

        [TestCaseSource(nameof(Cases))]
        public void then_failure(string emptyPhone)
        {
            Sut.Invoking(_ => _.Call(emptyPhone)).Should().Throw<ArgumentException>();
        }
    }
}