using System;
using BddStyle.NUnit.Utilities;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.given_file_in_resources
{
    public class when_reading_resource_with_external_caller : ContextBase
    {
        [Test]
        public void then_exception_is_thrown()
        {
            var callerWithoutResource = new TestAttribute();
            this.Invoking(_ =>
                    AssemblyResourceReader.ReadString(callerWithoutResource, "ResourceFile.txt"))
                .Should().Throw<Exception>();
        }
    }
}