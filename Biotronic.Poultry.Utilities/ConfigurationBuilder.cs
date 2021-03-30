using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using AutoMapper;
using Newtonsoft.Json;

[assembly: InternalsVisibleTo("Biotronic.Poultry.Tests")]

namespace Biotronic.Poultry.Utilities
{
    public class ConfigurationBuilder<TConfiguration> where TConfiguration : class
    {
        private readonly List<Func<TConfiguration, TConfiguration>> _sources = new List<Func<TConfiguration, TConfiguration>>();

        public void AddSource(Func<TConfiguration, TConfiguration> source)
        {
            _sources.Insert(0, source);
        }

        public TConfiguration Build()
        {
            var mapper = new Mapper(new MapperConfiguration(cfg =>
            {
            }));
            var result = Activator.CreateInstance<TConfiguration>();

            return _sources.Aggregate(result, (current, source) => mapper.Map(source(current), current));
        }
    }

    public static class ConfigurationBuilderExtensions
    {
        internal static ICommandLineReader CommandLineReader { get; set; }

        public static ConfigurationBuilder<TConfiguration> UseAppSettings<TConfiguration>(this ConfigurationBuilder<TConfiguration> config) where TConfiguration : class
        {
            var configuration = (CommandLineReader ?? new CommandLineReader()).GetCommandLineArgs()
                .Select(a => Regex.Match(a, "--configuration=(.*)"))
                .Where(a => a.Success)
                .Select(a => a.Groups[1].Value)
                .FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(configuration))
            {
                var parts = configuration.Split('.');

                for (var i = parts.Length; i > 0; --i)
                {
                    var cfg = string.Join(".", parts.Take(i)) + ".json";
                    if (File.Exists(cfg))
                    {
                        // Prevent mutation of captured variable
                        var tmpCfg = cfg;
                        config.AddSource(obj =>
                        {
                            JsonConvert.PopulateObject(File.ReadAllText(tmpCfg), obj);
                            return obj;
                        });
                    }
                }
            }
            else
            {
                config.AddSource(obj =>
                {
                    JsonConvert.PopulateObject(File.ReadAllText("AppSettings.json"), obj);
                    return obj;
                });
            }

            return config;
        }

        public static ConfigurationBuilder<TConfiguration> UseCommandLine<TConfiguration>(
            this ConfigurationBuilder<TConfiguration> config) where TConfiguration : class
        {

            return config;
        }
    }
}