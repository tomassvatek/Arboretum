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
    [Route( "api/Tree" )]
    public class TreeController : ControllerBase
    {
        private readonly ITreeService _service;


        public TreeController( ITreeService service )
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrees( IMapViewport viewport )
        {
            var trees = await _service.GetTreesAsync( new MapViewport());
            var vm = new List<TreeMapViewModel>( );

            foreach ( var tree in trees )
            {
                vm.Add( new TreeMapViewModel( tree.Id, tree.Dendrology.CommonName ) );
            }

            return Ok( vm );
        }


        [HttpGet]
        public async Task<IActionResult> GetTrees( IMapViewport viewport, LatLng latLng, int count )
        {
            // testing purpose
            var trees = _service.GetTreesAsync( new MapViewport(), new LatLng(), 5);

            if ( trees == null )
            {
                return NotFound( );
            }

            return Ok( trees );
        }

        [HttpGet]
        public IActionResult GetTree( int id )
        {
            var tree = _service.GetTree( id );

            if ( tree == null )
            {
                return NotFound( );
            }

            return Ok( tree );
        }

        [HttpPut]
        public IActionResult Add( TreeDto tree )
        {
            return NotFound( );
        }

        [HttpPut]
        public IActionResult Edit( TreeDto tree )
        {
            return NotFound( );
        }
    }
}