using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.given_context_base.and_act_suppressed;

public class when_executed_act_async_throws_exception : Context
{
    protected override Task ActAsync()
    {
        throw new AssertionException(nameof(ActAsync));
    }

    [Test]
    public void then_act_exception_is_thrown()
    {
        ShouldSuppressAct = false;
        this.Invoking(_ => _.SetUp()).Should().Throw<AssertionException>();
    }
}