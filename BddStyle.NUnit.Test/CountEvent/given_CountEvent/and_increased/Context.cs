namespace BddStyle.NUnit.Test.CountEvent.given_CountEvent.and_increased
{
    public class Context : given_CountEvent.Context
    {
        protected override void Arrange()
        {
            base.Arrange();
            Sut.Increase();
        }
    }
}