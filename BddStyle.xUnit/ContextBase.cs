using System;
using System.Diagnostics.CodeAnalysis;
using BddStyle.Common;

namespace BddStyle.xUnit;

[JetBrains.Annotations.UsedImplicitly]
public abstract class ContextBase : InternalContextBase, IDisposable
{
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    protected ContextBase()
    {
        ArrangeAndAct();
    }

    [SuppressMessage("Usage", "CA1816:Dispose methods should call SuppressFinalize")]
    public void Dispose()
    {
        Cleanup();
    }
}