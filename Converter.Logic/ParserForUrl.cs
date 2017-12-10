using System;
using System.Collections.Generic;
using System.Linq;

namespace Converter.Logic
{
    public class ParserForUrl
    {
        private string original;
        private string scheme;
        private string host;
        private string[] segments;
        private KeyValuePair<string, string>[] parameters;

        public string Original => original;
        public string Scheme => scheme;
        public string Host => host;
        public string[] Segments => segments;
        public KeyValuePair<string, string>[] Parameters => parameters;

        public static bool Parse(string urlString, out ParserForUrl url)
        {
            if (Uri.TryCreate(urlString, UriKind.Absolute, out Uri uri))
            {
                url = new ParserForUrl
                {
                    original = uri.OriginalString,
                    scheme = uri.Scheme,
                    host = uri.Host,
                    segments = uri.Segments.Length > 0 ? uri.Segments.Skip(1).Select(str => new string(str.TakeWhile(symbol => symbol != '/').ToArray())).ToArray() : null,
                    parameters = uri.Query.Length > 0 ? new string(uri.Query.Skip(1).ToArray()).Split('&').Select(str => new KeyValuePair<string, string>(new string(str.TakeWhile(symbol => symbol != '=').ToArray()), new string(str.SkipWhile(ch => ch != '=').Skip(1).ToArray()))).ToArray() : null
                };

                if (url.parameters != null && !url.parameters.All(par => par.Key != string.Empty && par.Value != string.Empty))
                {
                    return false;
                }

                return true;
            }

            url = default(ParserForUrl);
            return false;
        }
    }
}
