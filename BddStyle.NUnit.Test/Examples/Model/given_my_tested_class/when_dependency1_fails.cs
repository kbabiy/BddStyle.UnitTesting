using NUnit.Framework;

namespace BddStyle.NUnit.Test.Examples.Model.given_my_tested_class
{
    public class when_dependency1_fails : Context
    {
        protected override void Act()
        {
            base.Act();
        }

        [Test]
        public void then_dependency_was_called()
        {
        }

        [Test]
        public void then_exception_is_thrown()
        {
        }
    }
}