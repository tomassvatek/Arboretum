﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arboretum.Common;
using Arboretum.Common.Extensions;

namespace Arboretum.WebService.HttpClient
{
    public class RestClient : IHttpClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        public RestClient( )
        {
            _httpClient = new System.Net.Http.HttpClient( );
        }

        /// <summary>
        /// Fetches the data asynchronous.
        /// </summary>
        /// <param name="baseAddress">The base address.</param>
        /// <param name="query">The query string.</param>
        /// <param name="requestHeaders">The request headers.</param>
        /// <returns></returns>
        public async Task<string> FetchDataAsync( string baseAddress, string query, IList<RequestHeaders> requestHeaders )
        {
            _httpClient.BaseAddress = new Uri( baseAddress );
            _httpClient.DefaultRequestHeaders.Clear( );
            _httpClient.DefaultRequestHeaders.AddRange( requestHeaders );

            var response = await _httpClient.GetAsync(query);
            var result = await response.Content.ReadAsStringAsync( );

            return result;
        }
    }
}