using System;
using BddStyle.NUnit.Utilities;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.given_file_in_resources
{
    public class when_searching_for_unexisting_resource_in_all_loaded_assemblies : ContextBase
    {
        [Test]
        public void then_exception_occurs()
        {
            this.Invoking(_ => AssemblyResourceReader.Search("UnexistingResource.resx"))
                .Should().Throw<Exception>();
        }
    }
}