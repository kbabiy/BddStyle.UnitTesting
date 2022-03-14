using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.Examples.given_EventCount.and_increased_once
{
    public class when_in_a_long_wait : Context
    {
        protected override void Act()
        {
            Task.Factory.StartNew(() => Sut.WaitUntil(0, TimeSpan.FromMinutes(1)));
            Thread.Sleep(100);
        }

        [Test]
        public void then_next_decrease_is_not_blocked()
        {
            Sut.Decrease();
        }

        [Test]
        public void then_next_increase_is_not_blocked()
        {
            Sut.Increase();
        }
    }
}