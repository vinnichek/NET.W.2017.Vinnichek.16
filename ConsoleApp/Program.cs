using System;
using Converter.Logic;

namespace ConsoleApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            UrlConverter.ConvertToXml(UrlReader.ReadUrl("url.txt", new UrlLogger()), "url.xml");
            Console.Read();
        }
    }
}
