using BddStyle.Common;
using NUnit.Framework;

namespace BddStyle.NUnit
{
    [TestFixture]
    public abstract class ContextBase : ContextBaseCommon
    {
        [SetUp]
        public void SetUp()
        {
            ArrangeAndAct();
        }

        [TearDown]
        public void TearDown()
        {
            Cleanup();
        }
    }
}