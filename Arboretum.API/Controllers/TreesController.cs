using System.Collections.Generic;
using System.Threading.Tasks;
using Arboretum.API.ViewModels;
using Arboretum.Core.Modules.Locations;
using Arboretum.Core.Services;
using Arboretum.Core.WebServices;
using Microsoft.AspNetCore.Mvc;

namespace Arboretum.API.Controllers
{
    [Produces( "application/json" )]
    [Route( "api/[controller]" )]
    public class TreesController : ControllerBase
    {
        private readonly ITreeService _service;


        public TreesController( ITreeService service )
        {
            _service = service;
        }

        [HttpGet( "{id}" )]
        public IActionResult GetTree( int id )
        {
            var tree = _service.GetTree( id );

            if ( tree == null )
            {
                return NotFound( );
            }

            return Ok( tree );
        }

        [HttpGet( "Trees" )]
        public async Task<IActionResult> GetTreesByViewport( IMapViewport viewport )
        {
            var trees = await _service.GetTreesAsync( new MapViewport());
            var vm = new List<TreeMapViewModel>( );

            foreach ( var tree in trees )
            {
                vm.Add( new TreeMapViewModel( tree.Id, tree.Dendrology.CommonName ) );
            }

            return Ok( vm );
        }


        [HttpGet( "TreesQuiz" )]
        public async Task<IActionResult> GetTreesQuiz( IMapViewport viewport, LatLng currentLocation, int count )
        {
            // testing purpose
            var trees = _service.GetTreesAsync( new MapViewport(), new LatLng(), 5);

            if ( trees == null )
            {
                return NotFound( );
            }

            return Ok( trees );
        }


        [HttpPost]
        public IActionResult Create( [FromBody] TreeDto tree )
        {
            return NotFound( );

        }

        [HttpPut( "{id}" )]
        public IActionResult Edit( int id, TreeDto tree )
        {
            return NotFound( );
        }
    }
}