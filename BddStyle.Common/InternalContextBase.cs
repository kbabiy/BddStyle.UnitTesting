using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("BddStyle.NUnit")]
[assembly: InternalsVisibleTo("BddStyle.xUnit")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

namespace BddStyle.Common
{
    public class InternalContextBase
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
            private static readonly TaskFactory TaskFactory = new
                TaskFactory(CancellationToken.None,
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