using System.Diagnostics.CodeAnalysis;

namespace BddStyle.NUnit.Test.given_phone_created
{
    [SuppressMessage("ReSharper", "UnassignedField.Global")]
    public abstract class  Context : ContextBase
    {
        protected Phone Sut;
        protected const string TestPhoneNumber = "321-123-12";
        protected string TestPin = "3365";

        public override void Arrange()
        {
            Sut = new Phone(TestPin);
        }
    }
}