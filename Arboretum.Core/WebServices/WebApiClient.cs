using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Arboretum.Core.Extensions;
using Arboretum.Core.Models;
using Arboretum.Core.WebServices.Providers;

namespace Arboretum.Core.WebServices
{
    public class WebApiClient
    {
        private const string API_KEY = "User-Agent";
        private const string API_KEY_VALUE = "arboretum-client-api-consumer-98ebdf2f-6e82-4638-8a4c-24a13cca786e";

        private HttpClient _httpClient;

        public WebApiClient(IDataProvider provider)
        {
            _httpClient = new HttpClient( );
            //_httpClient.BaseAddress = provider.BaseAddress;
            //_httpClient.BaseAddress
        }

        public async Task<List<Tree>> ReadManyAsync( )
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear( );
            _httpClient.DefaultRequestHeaders.Add( API_KEY, API_KEY_VALUE );

            HttpResponseMessage httpResponse = await _httpClient.GetAsync( "https://www.stromypodkontrolou.cz/client_api/v1/trees?lat_min=49.27646333001661&lat_max=49.27769699366917&lon_min=17.5457698717305&lon_max=17.549203099269562" );
            HttpContent content = httpResponse.Content;
            string json = await content.ReadAsStringAsync( );
            return JsonExtension.DeserializeTrees( json );  
        }
    }
}
