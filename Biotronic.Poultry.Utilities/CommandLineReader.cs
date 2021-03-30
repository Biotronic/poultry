using System;

namespace Biotronic.Poultry.Utilities
{
    internal class CommandLineReader : ICommandLineReader
    {
        public string[] GetCommandLineArgs()
        {
            return Environment.GetCommandLineArgs();
        }
    }
}