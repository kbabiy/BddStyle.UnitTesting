using BddStyle.NUnit.Utilities;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.given_file_in_resources
{
    public class when_reading_resource_in_specified_assembly_into_string : ContextBase
    {
        [Test]
        public void then_resource_is_read_successfully()
        {
            AssemblyResourceReader.ReadString(this, "ResourceFile.txt")
                  .Should().Be("Resource content.");
        }
    }
}