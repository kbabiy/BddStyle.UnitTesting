namespace BddStyle.NUnit.Test.Examples.given_EventCount.and_increased_once
{
    public abstract class Context : given_EventCount.Context
    {
        protected override void Arrange()
        {
            base.Arrange();
            Sut.Increase();
        }
    }
}