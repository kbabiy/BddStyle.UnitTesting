namespace BddStyle.NUnit.Test.given_phone_created
{
    public abstract class Context : ContextBase
    {
        protected Phone Sut;
        protected const string TestPhoneNumber = "321-123-12";
        protected const string TestPin = "3365";

        protected override void Arrange()
        {
            Sut = new Phone(TestPin);
        }
    }
}