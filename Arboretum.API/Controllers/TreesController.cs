using System.Collections.Generic;
using System.Threading.Tasks;
using Arboretum.API.config;
using Arboretum.API.Models;
using Arboretum.API.ViewModels;
using Arboretum.Core.Helpers.Locations;
using Arboretum.Core.Helpers.Locations.Interfaces;
using Arboretum.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Arboretum.API.Controllers
{
    [Produces( "application/json" )]
    [Route( RestRoute.ControllerRoute )]
    public class TreesController : ControllerBase
    {
        private readonly ITreeService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreesController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public TreesController( ITreeService service )
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetTreesByViewport( )
        {
            //var trees = await _service.GetTreesAsync( new MapViewport());
            //var vm = new List<TreeMapViewModel>( );

            //foreach ( var tree in trees )
            //{
            //    vm.Add( new TreeMapViewModel( tree.Id, tree.Dendrology.CommonName ) );
            //}

            //return Ok( vm );
            var list = new List<MarkerDto>()
            {
                new MarkerDto()
                {
                    Id = 10,
                    Latitude = 37.78825,
                    Longitude = -122.4324,
                    Title = "Lípa"
                },
                new MarkerDto()
                {
                    Id = 10,
                    Latitude = 37.78825,
                    Longitude = -122.4324,
                    Title = "Lípa"
                },

                new MarkerDto()
                {
                    Id = 10,
                    Latitude = 37.78825,
                    Longitude = -122.4324,
                    Title = "Lípa"
                },

                new MarkerDto()
                {
                    Id = 10,
                    Latitude = 37.78825,
                    Longitude = -122.4324,
                    Title = "Lípa"
                },

                new MarkerDto()
                {
                    Id = 10,
                    Latitude = 37.78825,
                    Longitude = -122.4324,
                    Title = "Lípa"
                }
            };

            return Ok( list );
        }

        [HttpGet( RestRoute.GetNumberTrees )]
        public async Task<IActionResult> GetCountTrees( IMapViewport viewport, LatLng currentLocation, int count )  
        {
            // testing purpose
            var trees = _service.GetTreesAsync( new MapViewport(), new LatLng(), 5);

            if ( trees == null )
            {
                return NotFound( );
            }

            return Ok( trees );
        }

        /// <summary>
        /// Gets the tree.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet( RestRoute.GetTreeById )]
        public IActionResult GetTree( int id )
        {
            var tree = _service.GetTree( id );

            if ( tree == null )
            {
                return NotFound( );
            }

            return Ok( tree );
        }

        [HttpPost]
        public IActionResult CreateTree( AddTreeDto dto )
        {
            if ( ModelState.IsValid )
            {
                return Ok( );
            }

            return NotFound( );
        }

        [HttpPut( RestRoute.UpdateTree )]
        public IActionResult EditTree( int id, EditTreeDto tree )
        {
            return NotFound( );
        }
    }
}