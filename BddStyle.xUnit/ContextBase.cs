using System;

// ReSharper disable All

namespace BddStyle.xUnit
{
    public abstract class ContextBase : IDisposable
    {
        public virtual void Arrange()
        {
        }

        public virtual void Act()
        {
        }

        public virtual void Cleanup()
        {
        }

        protected virtual bool SuppressAct => false;

        internal void ActInternal()
        {
            if (!SuppressAct)
                Act();
        }

        public ContextBase()
        {
            Arrange();
            ActInternal();
        }

        public void Dispose()
        {
            Cleanup();
        }
    }
}