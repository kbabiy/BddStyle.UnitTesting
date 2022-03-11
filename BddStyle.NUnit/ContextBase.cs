using BddStyle.Common;
using NUnit.Framework;

namespace BddStyle.NUnit;

[TestFixture]
public abstract class ContextBase : InternalContextBase
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