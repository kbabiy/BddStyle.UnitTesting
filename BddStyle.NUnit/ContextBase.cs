using NUnit.Framework;

namespace BddStyle.NUnit
{
    public abstract class ContextBase : ContextBaseInternal
    {
        [SetUp]
        public void SetUp()
        {
            Arrange();
            ActInternal();
        }

        [TearDown]
        public void TearDown()
        {
            Cleanup();
        }
    }
}