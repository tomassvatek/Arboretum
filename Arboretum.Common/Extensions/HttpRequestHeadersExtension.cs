using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Arboretum.Common.Extensions
{
    public static class HttpRequestHeadersExtension
    {
        public static void AddRange( this HttpRequestHeaders httpRequestHeaders, IList<RequestHeaders> requestHeaders )
        {
            httpRequestHeaders.Clear( );

            foreach ( var item in requestHeaders )
            {
                httpRequestHeaders.Add( item.Name, item.Value );
            }
        }
    }
}
