using NUnit.Framework;

namespace BddStyle.NUnit
{
    [TestKind(Kinds.Integration)]
    public abstract class StaticContextBase : ContextBaseInternal
    {
        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            Arrange();
        }

        [SetUp]
        public void SetUp()
        {
            ActInternal();
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            CleanupInternal();
        }
    }
}