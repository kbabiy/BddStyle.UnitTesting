using System.Linq;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.given_integration_test
{
    [TestKind(Kinds.Integration)]
    public class when_loading : ContextBase
    {
        private CategoryAttribute[] _actualAttributes;

        public override void Arrange()
        {
            base.Arrange();
            _actualAttributes = GetType().GetCustomAttributes<CategoryAttribute>().ToArray();
        }

        [Test]
        public void then_only_integration_atttribute_is_left()
        {
            _actualAttributes.Should().OnlyContain(a => a.Name == "Integration");
        }

        [Test]
        public void then_only_one_attribute_exists()
        {
            _actualAttributes.Should().HaveCount(1);
        }
    }
}