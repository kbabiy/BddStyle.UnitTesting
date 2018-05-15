using BddStyle.NUnit.Utilities;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.given_file_in_resources
{
    public class when_searching_for_existing_resource_in_all_loaded_assemblies : ContextBase
    {
        [Test]
        public void then_resource_is_found()
        {
            AssemblyResourceReader.Search("ResourceFile.txt")
                  .Should().Be("Resource content.");
        }
    }
}