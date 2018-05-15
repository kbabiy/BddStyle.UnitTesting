using System;
using BddStyle.NUnit.Utilities;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.given_file_in_resources
{
    public class when_reading_unexisting_resource_in_specified_assembly_into_string : ContextBase
    {
        [Test]
        public void then_exception_is_thrown()
        {
            this.Invoking(_ => AssemblyResourceReader.ReadString(this, "UnexistingResource"))
                .Should().Throw<Exception>();
        }
    }
}