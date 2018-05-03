using System.Linq;
using System.Threading.Tasks;
using Arboretum.API.Viewmodels;
using Arboretum.Core.Models.Locations;
using Arboretum.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Arboretum.API.Controllers
{
    [Produces( "application/json" )]
    [Route( "api/Tree" )]
    public class TreeController : ControllerBase
    {
        private readonly ITreeRepository _repository;

        public TreeController( ITreeRepository repository )
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTreesAsync( [FromQuery] MapViewport viewport )
        {
            var trees = await _repository.GetTrees( viewport );
            if ( trees == null )
            {
                return BadRequest( );
            }
            var vm = trees.Select( e => new TreeInfoWindowVm
            {
                Id = e.Id,
                SpeciesCommonName = e.SpeciesCommonName
            } ).ToList( );

            return Ok( vm );
        }
    }
}