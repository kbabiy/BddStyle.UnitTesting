using System;
using BddStyle.NUnit.Utilities;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.given_xml_with_xdt_transformation
{
    public class when_applying_wrong_transformation : Context
    {
        [Test]
        public void then_exception_occurs()
        {
            Action action = () =>
                XmlTransformator.ApplyTransformation(this, "Web.config", "transformations.WrongTransformation.xml");

            action.Should().Throw<Exception>()
                .WithMessage("No attribute 'UnexistingAttribute' exists for the Match Locator");
        }
    }
}