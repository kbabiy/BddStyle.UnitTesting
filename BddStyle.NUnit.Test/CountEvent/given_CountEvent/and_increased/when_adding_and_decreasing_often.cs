using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.CountEvent.given_CountEvent.and_increased
{
    public class when_adding_and_decreasing_often : Context
    {
        [SuppressMessage("ReSharper", "FunctionNeverReturns")]
        protected override void Act()
        {
            Task.Factory.StartNew(() =>
                    {
                        while (true)
                        {
                            Sut.Increase();
                            Thread.Sleep(100);
                            Sut.Decrease();
                        }
                    }
                );
        }

        [Test]
        public void then_wait_returns_false_by_timeout()
        {
            Timed(TimeSpan.FromSeconds(3),
                () => Sut.WaitUntil(0, TimeSpan.FromSeconds(1)))
                .Should().BeFalse();
        }
    }
}