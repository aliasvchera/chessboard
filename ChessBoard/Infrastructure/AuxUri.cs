using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessBoard.Extention
{
    public static class AuxUri
    {
        public static Uri GetUri(this HttpRequest request, bool addPath = true, bool addQuery = true)
        {
            var uriBuilder = new UriBuilder
            {
                Scheme = request.Scheme,
                Host = request.Host.Host,
                Port = request.Host.Port.GetValueOrDefault(80),
                Path = addPath ? request.Path.ToString() : default(string),
                Query = addQuery ? request.QueryString.ToString() : default(string)
            };
            return uriBuilder.Uri;
        }

        public static string HostWithNoSlash(this Uri uri)
        {
            return uri.GetComponents(UriComponents.SchemeAndServer, UriFormat.UriEscaped);
        }
    }
}
