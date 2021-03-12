using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;

namespace RulesEngineLibrary
{
    public static class AppConfig
    {
        private static string _fileName => "appsettings.json";
        public static string PluginPath()
        {
            if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), _fileName)))
            {
                var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
                return new FileInfo(location.AbsolutePath).Directory.ToString();
            }

            var configuration = new ConfigurationBuilder()
           .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), _fileName), optional: false)
           .Build();
            return configuration.GetSection("AppSettings").GetSection("PluginPath").Value;

        }
    }
}