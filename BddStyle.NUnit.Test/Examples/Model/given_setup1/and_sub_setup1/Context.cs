using NUnit.Framework;

namespace BddStyle.NUnit.Test.Examples.Model.given_setup1.and_sub_setup1
{
    public abstract class Context : given_setup1.Context
    {
        protected override void Arrange()
        {
            base.Arrange();
        }
    }
}