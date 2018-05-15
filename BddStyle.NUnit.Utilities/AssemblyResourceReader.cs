using System;
using System.IO;
using System.Linq;

// ReSharper disable UnusedMember.Global

namespace BddStyle.NUnit.Utilities
{
    public static class AssemblyResourceReader
    {
        public static string Search(string resourcePath)
        {
            using (var stream = FindStream(resourcePath))
            {
                return ReadResourceContent(stream);
            }
        }

        public static string ReadAppConfig(object caller)
        {
            return ReadResource(caller.GetType(), "App.config", false);
        }

        public static string ReadString(object caller, string resourceName, bool lookupInParentNamespaces = false)
        {
            return ReadResource(caller.GetType(), resourceName, lookupInParentNamespaces);
        }

        public static Stream ReadStream(object caller, string resourceName)
        {
            var callerType = caller.GetType();

            return GetStream(callerType, resourceName, false);
        }

        private static string ReadResource(Type callerType, string resourceName, bool lookupInParentNamespaces)
        {
            using (var stream = GetStream(callerType, resourceName, lookupInParentNamespaces))
            {
                if (stream == null)
                    throw new Exception($"Can not find resource {resourceName} in assembly {callerType.Assembly.FullName}");

                return ReadResourceContent(stream);
            }
        }

        private static Stream GetStream(Type callerType, string resourceName, bool lookupInParentNamespaces)
        {
            var ns = callerType.Namespace;
            if (ns == null)
                return null;

            Stream result;
            do
            {
                var path = GetResourcePath(ns, resourceName);
                result = callerType.Assembly.GetManifestResourceStream(path);
                if (result != null)
                    break;

                var lastDotIndex = ns.LastIndexOf('.');
                if (lastDotIndex < 0)
                    break;

                ns = ns.Substring(0, lastDotIndex);
                // ReSharper disable once LoopVariableIsNeverChangedInsideLoop
            } while (lookupInParentNamespaces);

            return result;
        }

        private static string GetResourcePath(string ns, string resourceName)
        {
            return $"{ns}.{resourceName}";
        }

        private static Stream FindStream(string resourceName)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var ns in assembly.GetTypes().Select(t => t.Namespace).Distinct())
                {
                    var resourcePath = GetResourcePath(ns, resourceName);
                    var stream = assembly.GetManifestResourceStream(resourcePath);

                    if (stream == null)
                        continue;

                    return stream;
                }
            }

            throw new Exception($"Can not find resource {resourceName} in all assemblies.");
        }

        private static string ReadResourceContent(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}