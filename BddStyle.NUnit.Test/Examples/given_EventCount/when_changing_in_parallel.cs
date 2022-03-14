﻿using System;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.Examples.given_EventCount
{
    public class when_changing_in_parallel : Context
    {
        protected override void Act()
        {
            StartIncreases();
            Thread.Sleep(100);
            StartDecreases();
        }

        [Test]
        public void then_wait_is_successful()
        {
            Sut.WaitUntil(0, TimeSpan.FromSeconds(10)).Should().BeTrue();
        }
    }
}