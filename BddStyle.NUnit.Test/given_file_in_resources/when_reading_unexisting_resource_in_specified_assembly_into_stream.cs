using System.IO;
using BddStyle.NUnit.Utilities;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.given_file_in_resources
{
    public class when_reading_unexisting_resource_in_specified_assembly_into_stream : ContextBase
    {
        private Stream _stream;

        public override void Act()
        {
            _stream = AssemblyResourceReader.ReadStream(this, "UnexistingResourceFile.txt");
        }

        [Test]
        public void then_null_is_returned()
        {
            _stream.Should().BeNull();
        }
    }
}