using System;
using Biotronic.Poultry.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Biotronic.Poultry.Tests
{
    [TestClass]
    public class ConfigTests
    {
        internal class TestConfig
        {
            internal class TestValueSet
            {
                public int TestValue1 { get; set; }

                public int TestValue2 { get; set; }
            }

            public TestValueSet TestValues { get; set; }
        }

        [TestMethod]
        public void TestConfigOrder()
        {
            var configBuilder = new ConfigurationBuilder<TestConfig>();

            configBuilder.AddSource(obj => new TestConfig { TestValues = new TestConfig.TestValueSet { TestValue1 = 1 } });
            configBuilder.AddSource(obj => new TestConfig { TestValues = new TestConfig.TestValueSet { TestValue1 = 2 } });

            var config = configBuilder.Build();

            Assert.AreEqual(1, config.TestValues.TestValue1);
        }

        internal class TestCommandLineReader : ICommandLineReader
        {
            private readonly Func<string[]> _func;

            public TestCommandLineReader(Func<string[]> func)
            {
                _func = func;
            }

            public string[] GetCommandLineArgs()
            {
                return _func();
            }
        }

        [TestMethod]
        public void TestJsonConfig()
        {
            ConfigurationBuilderExtensions.CommandLineReader = new TestCommandLineReader(() => new[] { "--configuration=AppSettings.Development.json" });

            var configBuilder = new ConfigurationBuilder<TestConfig>();
            configBuilder.UseAppSettings();

            var config = configBuilder.Build();

            Assert.AreEqual(7, config.TestValues.TestValue1);
            Assert.AreEqual(-15, config.TestValues.TestValue2);
        }
    }
}
