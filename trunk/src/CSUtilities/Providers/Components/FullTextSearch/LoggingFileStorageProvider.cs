using System;
using System.IO;

namespace CSUtilities.Providers.Components.FullTextSearch
{
    public class LoggingFileStorageProvider : ILoggingStorageProvider
    {
        public void Log(LoggingResult result)
        {
            File.WriteAllText(@"c:\tmp\log.txt", DateTime.Now.ToString());
        }
    }
}