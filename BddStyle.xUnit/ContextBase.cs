using System;

// ReSharper disable All

namespace BddStyle.xUnit
{
    public abstract class ContextBase : IDisposable
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

        public ContextBase()
        {
            Arrange();
            if (!SuppressAct)
                Act();
        }

        public void Dispose()
        {
            Cleanup();
        }
    }
}