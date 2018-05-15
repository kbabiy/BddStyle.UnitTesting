using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

namespace BddStyle.NUnit.Utilities
{
    public abstract class AppConfig : IDisposable
    {
        public static AppConfig ChangeByContents(string contents)
        {
            var tempConfig = Path.GetTempFileName();
            File.WriteAllText(tempConfig, contents);
            return ChangeByPath(tempConfig, true);
        }

        public static AppConfig ChangeByPath(string path, bool deleteConfigOnDisposal = false)
        {
            return new ChangeAppConfig(path, deleteConfigOnDisposal);
        }

        public static AppConfig ChangeByResource(object caller, string configResourceName)
        {
            var configContents = AssemblyResourceReader.ReadString(caller, configResourceName, true);

            return ChangeByContents(configContents);
        }

        public static AppConfig TransformAndChangeByResource(object caller, string configResourceName, string transformationResourceName)
        {
            var configContents = XmlTransformator.ApplyTransformation(caller, configResourceName, transformationResourceName);

            return ChangeByContents(configContents);
        }

        public abstract void Dispose();

        private class ChangeAppConfig : AppConfig
        {
            private readonly string _oldConfig =
                AppDomain.CurrentDomain.GetData("APP_CONFIG_FILE").ToString();

            private readonly string _configToCleanup;

            private bool _disposedValue;

            public ChangeAppConfig(string path, bool deleteConfigOnDisposal)
            {
                if (deleteConfigOnDisposal)
                    _configToCleanup = path;

                AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", path);
                ResetConfigMechanism();
            }

            public override void Dispose()
            {
                if (!_disposedValue)
                {
                    AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", _oldConfig);
                    ResetConfigMechanism();
                    try
                    {
                        if (_configToCleanup != null && File.Exists(_configToCleanup))
                            File.Delete(_configToCleanup);
                    }
                    // ReSharper disable once EmptyGeneralCatchClause
                    catch { }
                    _disposedValue = true;
                }
                GC.SuppressFinalize(this);
            }

            private static void ResetConfigMechanism()
            {
                var configType = typeof(ConfigurationManager);

                // ReSharper disable PossibleNullReferenceException
                configType.GetField("s_initState", BindingFlags.NonPublic | BindingFlags.Static)
                    .SetValue(null, 0);
                configType.GetField("s_configSystem", BindingFlags.NonPublic | BindingFlags.Static)
                    .SetValue(null, null);

                configType.Assembly.GetTypes()
                    .First(x => x.FullName == "System.Configuration.ClientConfigPaths")
                    .GetField("s_current", BindingFlags.NonPublic | BindingFlags.Static)
                    .SetValue(null, null);
                // ReSharper restore PossibleNullReferenceException
            }
        }
    }
}