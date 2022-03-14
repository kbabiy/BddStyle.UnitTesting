namespace BddStyle.NUnit.Test.Examples.given_phone_created.and_unlocked
{
    public abstract class Context : given_phone_created.Context
    {
        protected override void Arrange()
        {
            base.Arrange();
            Sut.Unlock(TestPin);
        }
    }
}