using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("BddStyle.NUnit")]
[assembly: InternalsVisibleTo("BddStyle.xUnit")]

namespace BddStyle.Common
{
    public class ContextBaseCommon
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
    }
}