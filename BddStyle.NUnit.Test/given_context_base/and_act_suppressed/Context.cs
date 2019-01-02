namespace BddStyle.NUnit.Test.given_context_base.and_act_suppressed
{
    public abstract class Context : given_context_base.Context
    {
        protected bool ShouldSuppressAct = true;
        protected override bool SuppressAct => ShouldSuppressAct;
    }
}