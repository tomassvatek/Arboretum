using Arboretum.Core.Enums;
using Arboretum.Core.Extensions;
using Arboretum.Core.Helpers.DataProviders.Interfaces;
using Arboretum.Core.Helpers.Locations.Interfaces;
using Arboretum.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Arboretum.Core.Helpers.DataProviders
{
    public class RestDataProvider : IFechData
    {
        protected HttpClient _httpClient;

        public RestDataProvider( )
        {
            _httpClient = new HttpClient( );
        }

        [JsonConverter( typeof( StringEnumConverter ) )]
        public ProviderName Name { get; set; }

        public Uri BaseAddress { get; set; }

        public List<RequestHeaders> RequestHeaders { get; set; } = new List<RequestHeaders>( );


        /// <summary>
        /// Fetches the data asynchronous.
        /// </summary>
        /// <param name="viewport">The map viewport.</param>
        /// <returns></returns>
        public async Task<List<Tree>> FetchDataAsync( IMapViewport viewport )
        {
            // Initializes http client
            _httpClient.BaseAddress = this.BaseAddress;
            _httpClient.DefaultRequestHeaders.AddRange( RequestHeaders );

            var response = await _httpClient.GetAsync(BuildUrl(viewport));
            var json = await response.Content.ReadAsStringAsync();
            return json.DeserializeTrees( );
        }

        #region Providers building url methods

        /// <summary>
        /// Builds the URL for the provider.
        /// </summary>
        /// <param name="viewport">The map viewport.</param>
        /// <returns>The paramater part of url.</returns>
        private string BuildUrl( IMapViewport viewport )
        {
            switch ( Name )
            {
                case ProviderName.SPK:
                    return BuildUrlSpkProvider( viewport );
                default:
                    return String.Empty;
            }
        }

        /// <summary>
        /// Builds the URL for SPK provider.
        /// </summary>
        /// <param name="viewport">The map viewport.</param>
        /// <returns></returns>
        private string BuildUrlSpkProvider( IMapViewport viewport )
        {
            return $"?lat_min={viewport.LatitudeMin}&lat_max={viewport.LatitudeMax}&lon_min={viewport.LongitudeMin}&lon_max={viewport.LongitudeMax}";
        }

        #endregion
    }
}
