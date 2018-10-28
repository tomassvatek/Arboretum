using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Models.Interfaces;
using Arboretum.Common;
using Arboretum.WebService.Helpers;
using Arboretum.WebService.HttpClient;
using Arboretum.WebService.Providers.Interfaces;

namespace Arboretum.WebService.Providers.SPK
{
    public class SPK : ITreeDataProvider
    {
        private readonly IHttpClient _httpClient;

        public SPK( IHttpClient httpClient )
        {
            _httpClient = httpClient;

            // TODO: Move to config file.
            Name = ProviderName.SPK;
            BaseAddress = "https://www.stromypodkontrolou.cz/client_api/v1/trees";
            RequestHeaders.Add( new RequestHeaders( "User-Agent", "arboretum-client-api-consumer-98ebdf2f-6e82-4638-8a4c-24a13cca786e" ) );
        }

        public ProviderName Name { get; }
        public string BaseAddress { get; }
        public bool IsEditable { get; } = false;
        public IList<RequestHeaders> RequestHeaders { get; set; } = new List<RequestHeaders>( );

        public async Task<System.Collections.Generic.IList<Tree>> GetTreesAsync( IRegion region )
        {
            string json = await _httpClient.FetchDataAsync( BaseAddress, $"?lat_min={region.LatitudeMin}&lat_max={region.LatitudeMax}&lon_min={region.LongitudeMin}&lon_max={region.LongitudeMax}", RequestHeaders );
            var trees = MapToDomain( json );

            return trees;
        }

        private List<Tree> MapToDomain( string json )
        {
            var dtos = JsonHelper<TreeDto>.DeserializeTrees( json );
            if ( dtos == null )
            {
                throw new ArgumentException( );
            }

            var trees = new List<Tree>();
            foreach ( var dto in dtos )
            {
                trees.Add( new Tree
                {
                    Id = dto.Id,
                    Age = dto.Age,
                    CrownSize = dto.CrownSize,
                    Height = dto.Height,
                    Note = dto.Note,
                    TrunkSize = dto.TrunkSize,
                    Dendrology = new Dendrology
                    {
                        CommonName = dto.CommonName,
                        ScientificName = dto.ScientificName
                    },
                    Location = new Location
                    {
                        Latitude = dto.Coordinates.Latitude,
                        Longitude = dto.Coordinates.Longitude
                    },
                    IsEditable = this.IsEditable
            } );
        }
            return trees;
        }
}
}