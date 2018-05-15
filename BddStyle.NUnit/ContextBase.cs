using NUnit.Framework;

namespace BddStyle.NUnit
{
    [TestKind(Kinds.Unit)]
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
            CleanupInternal();
        }
    }
}