using Arboretum.Core.Extensions;
using Arboretum.Core.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Arboretum.Core.WebServices
{
    public class RestService
    {
        private readonly HttpClient _httpClient;

        public RestService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.BaseAddress = new Uri("https://www.stromypodkontrolou.cz/client_api/v1/trees");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "arboretum-client-api-consumer-98ebdf2f-6e82-4638-8a4c-24a13cca786e");
        }

        public async Task<List<Tree>> ReadManyAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("?lat_min=50.10090883137793&lat_max=50.10090883137793&lon_min=14.451601214953257&lon_max=14.451601214953257");
            var content = response.Content;
            string json = await content.ReadAsStringAsync();
            return json.DeserializeTree();
        }
    }
}
