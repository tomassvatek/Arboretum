using System;
using System.Collections.Generic;

namespace Arboretum.Core.WebServices.Providers
{
    public class SPKProvider : IDataProvider
    {
        private const string API_KEY = "User-Agent";
        private const string API_KEY_VALUE = "arboretum-client-api-consumer-98ebdf2f-6e82-4638-8a4c-24a13cca786e";
        public string ProviderName { get { return "SPK"; } }
        public Uri BaseAddress { get { return new Uri( "https://www.stromypodkontrolou.cz/client_api/v1/trees?lat_min=49.27646333001661&lat_max=49.27769699366917&lon_min=17.5457698717305&lon_max=17.549203099269562" ); } }
        public List<RequestHeader> RequestHeaders { get; }

        public SPKProvider( )
        {
            RequestHeaders.Add( new RequestHeader( API_KEY, API_KEY_VALUE ) );
        }
    }
}
