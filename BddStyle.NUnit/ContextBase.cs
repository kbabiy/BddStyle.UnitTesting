using NUnit.Framework;

namespace BddStyle.NUnit
{
    [TestFixture]
    public abstract class ContextBase
    {
        protected virtual void Arrange()
        {
        }

        protected virtual void Act()
        {
        }

        protected virtual void Cleanup()
        {
        }

        protected virtual bool SuppressAct => false;

        [SetUp]
        public void SetUp()
        {
            Arrange();
            if (!SuppressAct)
                Act();
        }

        [TearDown]
        public void TearDown()
        {
            Cleanup();
        }
    }
}