using System;
using System.Collections.Generic;

namespace Arboretum.Core.WebServices.Providers
{
    public class SPKProvider : IDataProvider
    {
        // Provider data (move to json file?)
        private const string PROVIDER_NAME = "SPK";
        private const string BASE_ADDRESS = "https://www.stromypodkontrolou.cz/client_api/v1/trees";
        private const string API_KEY = "User-Agent";
        private const string API_KEY_VALUE = "arboretum-client-api-consumer-98ebdf2f-6e82-4638-8a4c-24a13cca786e";

        private List<RequestHeader> _requestHeaders;

        public string ProviderName
        {
            get { return PROVIDER_NAME; }
        }
        public Uri BaseAddress { get { return new Uri( BASE_ADDRESS ); } }

        public List<RequestHeader> RequestHeaders
        {
            get
            {
                _requestHeaders.Add( new RequestHeader( API_KEY, API_KEY_VALUE ) );
                return _requestHeaders;
            }
        }

        public SPKProvider()
        {
            _requestHeaders = new List<RequestHeader>();
            _requestHeaders.Clear();
        }
    }
}
