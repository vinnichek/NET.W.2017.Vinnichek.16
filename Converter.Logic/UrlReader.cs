using System.Collections.Generic;
using System.IO;

namespace Converter.Logic
{
    public class UrlReader
    {
        public static ParserForUrl[] ReadUrl(string path, ILogger logger)
        {
            using (var reader = new StreamReader(File.OpenRead(path)))
            {
                var urlList = new List<ParserForUrl>();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (ParserForUrl.Parse(line, out ParserForUrl url))
                    {
                        urlList.Add(url);
                    }
                    else
                    {
                        logger.Log(line);
                    }
                }

                return urlList.ToArray();
            }
        }
    }
}
