using System.IO;
using BddStyle.NUnit.Utilities;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.given_file_in_resources
{
    public class when_reading_resource_in_specified_assembly_into_stream : ContextBase
    {
        private string _content;

        public override void Act()
        {
            using (var stream = AssemblyResourceReader.ReadStream(this, "ResourceFile.txt"))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    _content = streamReader.ReadToEnd();
                }
            }
        }

        [Test]
        public void then_resource_is_read_successfully()
        {
            _content.Should().Be("Resource content.");
        }
    }
}