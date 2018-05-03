using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arboretum.Core.Models.Entities;
using Arboretum.Core.Models.Locations;
using Arboretum.Core.WebServices;
using Arboretum.Core.WebServices.Providers;

namespace Arboretum.Core.Repositories
{
    public class TreeRepository : ITreeRepository
    {
        private readonly HttpClient _httpClient;

        public TreeRepository(IDataProvider provider)
        {
            _httpClient = new HttpClient(provider);
        }

        public Tree GetTreeById( int id )
        {
            throw new NotImplementedException( );
        }

        public async Task<IEnumerable<Tree>> GetTrees( IMapViewport viewport )
        {
            var trees =  await _httpClient.ReadManyAsync("?lat_min=49.27646333001661&lat_max=49.27769699366917&lon_min=17.5457698717305&lon_max=17.549203099269562");
            return trees;
        }
    }
}
