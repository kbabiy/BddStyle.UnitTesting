using NUnit.Framework;

namespace BddStyle.NUnit.Test.Examples.Model.given_my_tested_class
{
    public class when_method_1_called : Context
    {
        protected override void Act()
        {
            base.Act();
        }

        [Test]
        public void then_expected_result_returned()
        {
        }

        [Test]
        public void then_result_is_not_empty()
        {
        }

        [Test]
        public void then_dependency_is_called_twice()
        {
        }
    }
}