using System;
using System.Diagnostics.CodeAnalysis;
using BddStyle.Common;

namespace BddStyle.xUnit
{
    public abstract class ContextBase : ContextBaseCommon, IDisposable
    {
        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        protected ContextBase()
        {
            ArrangeAndAct();
        }

        public void Dispose()
        {
            Cleanup();
        }
    }
}