using System;
using NUnit.Framework;

namespace BddStyle.NUnit
{
    // ReSharper disable RedundantAttributeUsageProperty
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,
        AllowMultiple = false, Inherited = true)]
    public class TestKindAttribute : CategoryAttribute
    {
        public TestKindAttribute(Kinds kind)
            : base(GetName(kind))
        {
        }

        private static string GetName(Kinds kind)
        {
            switch (kind)
            {
                case Kinds.Unit: return "Unit";
                case Kinds.Integration: return "Integration";
                default: throw new NotSupportedException("Unsupported test kind: " + kind);
            }
        }
    }
}