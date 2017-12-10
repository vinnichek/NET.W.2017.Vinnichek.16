using System;
namespace Converter.Logic
{
    public class UrlLogger : ILogger
    {
        public UrlLogger() {}
        
        public void Log(string url)
        {
            if (!string.IsNullOrWhiteSpace(url))
            {
                Console.WriteLine(url);
            }
        }
    }
}
