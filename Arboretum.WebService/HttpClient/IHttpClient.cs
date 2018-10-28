using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arboretum.Common;

namespace Arboretum.WebService.HttpClient
{
    public interface IHttpClient
    {
        Task<string> FetchDataAsync( string baseAddress, string query, IList<RequestHeaders> requestHeaders );  
    }
}