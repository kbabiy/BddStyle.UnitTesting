using System;
using BddStyle.NUnit.Utilities;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.given_file_in_resources.and_child_namespace
{
    public class when_reading_resource_in_specified_assembly_into_string : ContextBase
    {
        [Test]
        public void then_by_default_resource_is_not_found()
        {
            var action = new Action(() => AssemblyResourceReader.ReadString(this, "ResourceFile.txt"));
            action.Should().Throw<Exception>();
        }

        [Test]
        public void then_with_parent_namespaces_resource_is_found()
        {
            AssemblyResourceReader.ReadString(this, "ResourceFile.txt", true)
                .Should().Be("Resource content.");
        }
    }
}