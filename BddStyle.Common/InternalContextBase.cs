using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

[assembly: InternalsVisibleTo("BddStyle.NUnit")]
[assembly: InternalsVisibleTo("BddStyle.xUnit")]

namespace BddStyle.Common
{
#pragma warning disable CS1998
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public abstract class InternalContextBase
    {
        protected virtual bool SuppressAct => false;

        protected virtual void Arrange()
        {
        }

        protected virtual async Task ArrangeAsync()
        {
        }

        protected virtual void Act()
        {
        }

        protected virtual async Task ActAsync()
        {
        }

        protected virtual void Cleanup()
        {
        }

        internal void ArrangeAndAct()
        {
            Arrange();
            AsyncHelper.RunSync(ArrangeAsync);

            if (SuppressAct) return;

            Act();
            AsyncHelper.RunSync(ActAsync);
        }


        private static class AsyncHelper
        {
            private static readonly TaskFactory TaskFactory = new(CancellationToken.None,
                TaskCreationOptions.None,
                TaskContinuationOptions.None,
                TaskScheduler.Default);

            internal static void RunSync(Func<Task> func)
                => TaskFactory
                    .StartNew(func)
                    .Unwrap()
                    .GetAwaiter()
                    .GetResult();
        }
    }
}