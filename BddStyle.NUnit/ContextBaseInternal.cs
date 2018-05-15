using NUnit.Framework;

// ReSharper disable All

namespace BddStyle.NUnit
{
    [TestFixture]
    public abstract class ContextBaseInternal
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

        internal void CleanupInternal()
        {
            Cleanup();
        }
    }
}