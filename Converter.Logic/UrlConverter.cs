using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Converter.Logic
{
    public static class UrlConverter
    {
        public static void ConvertToXml(IEnumerable<ParserForUrl> urls, string path)
        {
            var writer = new XmlTextWriter(path, Encoding.UTF8);

            writer.WriteStartDocument();
            writer.WriteStartElement("urlAddresses");

            foreach (var url in urls)
            {
                WriteURL(url);
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            return;

            void WriteURL(ParserForUrl url)
            {
                writer.WriteStartElement("urlAddress");
                writer.WriteAttributeString("scheme", url.Scheme);
                WriteHost();
                WritePath();
                WriteParameters();
                writer.WriteEndElement();
                return;

                void WriteHost()
                {
                    writer.WriteStartElement("host");
                    writer.WriteAttributeString("name", url.Host);
                    writer.WriteEndElement();
                }

                void WritePath()
                {
                    if (url.Segments?.Length > 0)
                    {
                        writer.WriteStartElement("uri");
                        foreach (var segment in url.Segments)
                        {
                            writer.WriteElementString("segment", segment);
                        }

                        writer.WriteEndElement();
                    }
                }

                void WriteParameters()
                {
                    if (url.Parameters?.Length > 0)
                    {
                        writer.WriteStartElement("parameters");
                        foreach (var param in url.Parameters)
                        {
                            writer.WriteStartElement("parameter");
                            writer.WriteAttributeString("key", param.Key);
                            writer.WriteAttributeString("value", param.Value);
                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();
                    }
                }
            }
        }
    }
}