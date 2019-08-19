﻿using System;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.CountEvent.given_CountEvent
{
    public class when_waiting_on_unchanged : Context
    {
        [Test]
        public void then_returns_success_immediately()
        {
            Timed(TimeSpan.FromMilliseconds(100),
                () => Sut.WaitUntil(0, TimeSpan.FromSeconds(10)))
                .Should().BeTrue();
        }
    }
}