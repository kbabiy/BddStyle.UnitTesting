using BddStyle.NUnit.Utilities;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.given_xml_with_xdt_transformation
{
    public class when_applying_correct_transformation : Context
    {
        public override void Act()
        {
            TransformedContent = 
                XmlTransformator.ApplyTransformation(this, "Web.config", "transformations.CorrectTransformation.xml");
        }

        [Test]
        public void then_transformation_applied_correctly()
        {
            GetStoragePathAttribute().Should().Be("transformedValue");
        }
    }
}