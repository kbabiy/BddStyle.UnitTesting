using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BddStyle.NUnit.Test.given_context_base
{
    public abstract class Context : ContextBase
    {
        protected readonly List<string> Calls = new List<string>();

        private void RegisterCall([CallerMemberName] string callerName = "none")
        {
            Calls.Add(callerName);
        }

        protected override void Arrange()
        {
            RegisterCall();
        }

        protected override Task ArrangeAsync()
        {
            RegisterCall();
            return Task.CompletedTask;
        }

        protected override void Act()
        {
            RegisterCall();
        }

        protected override Task ActAsync()
        {
            RegisterCall();
            return Task.CompletedTask;
        }

        protected override void Cleanup()
        {
            RegisterCall();
        }
    }
}