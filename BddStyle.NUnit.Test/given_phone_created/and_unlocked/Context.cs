namespace BddStyle.NUnit.Test.given_phone_created.and_unlocked
{
    public abstract class Context : given_phone_created.Context
    {
        public override void Arrange()
        {
            base.Arrange();
            Sut.Unlock(TestPin);
        }
    }
}