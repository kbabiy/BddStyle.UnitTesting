﻿using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.given_context_base
{
    public class when_executed : Context
    {
        [Test]
        public void then_calls_are_as_expected()
        {
            Calls.Should().BeEquivalentTo(
                nameof(Arrange), nameof(ArrangeAsync), nameof(Act), nameof(ActAsync));
        }
    }
}