using System.Threading.Tasks;
using Arboretum.AppCore.Models;
using Arboretum.WebService.Interfaces;

namespace Arboretum.WebService.Providers.SPK
{
    public class SPK : ITreeProvider
    {
        public SPK( )
        {
            Name = ProviderName.SPK;
            //BaseAddress = 
        }

        public ProviderName Name { get; }
        public string BaseAddress { get; }

        public Task<System.Collections.Generic.IList<Tree>> GetTrees( IMapViewport mapViewport )
        {
            throw new System.NotImplementedException( );
        }
    }
}