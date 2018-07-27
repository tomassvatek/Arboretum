using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Arboretum.Core.Extensions;
using Arboretum.Core.Models;
using Arboretum.Core.WebServices.Providers;

namespace Arboretum.Core.WebServices
{
    public class HttpClient
    {
        //private const string API_KEY = "User-Agent";
        //private const string API_KEY_VALUE = "arboretum-client-api-consumer-98ebdf2f-6e82-4638-8a4c-24a13cca786e";

        private System.Net.Http.HttpClient _httpClient;

        public HttpClient( IDataProvider provider )
        {
            _httpClient = new System.Net.Http.HttpClient( );
            _httpClient.DefaultRequestHeaders.Accept.Clear( );
            _httpClient.BaseAddress = provider.BaseAddress;
            _httpClient.DefaultRequestHeaders.Clear();
            AddRequestHeaders( provider.RequestHeaders );
        }

        public async Task<List<Tree>> ReadManyAsync( string parameters )
        {
            //HttpResponseMessage httpResponse = await _httpClient.GetAsync( "?lat_min=49.27646333001661&lat_max=49.27769699366917&lon_min=17.5457698717305&lon_max=17.549203099269562" );
            HttpResponseMessage httpResponse = await _httpClient.GetAsync( parameters );
            HttpContent content = httpResponse.Content;
            string json = await content.ReadAsStringAsync( );
            return json.DeserializeTree( );
        }

        private void AddRequestHeaders( List<RequestHeader> requestHeaders )
        {
            foreach ( var requestHeader in requestHeaders )
            {
                _httpClient.DefaultRequestHeaders.Add( requestHeader.Key, requestHeader.Value );
            }
        }
    }
}
