using System.Collections.Generic;
using System.Threading.Tasks;
using Arboretum.API.Models;
using Arboretum.API.ViewModels;
using Arboretum.Core.Helpers.Locations;
using Arboretum.Core.Helpers.Locations.Interfaces;
using Arboretum.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Arboretum.API.Controllers
{
    [Produces( "application/json" )]
    [Route( "api/[controller]" )]
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

        /// <summary>
        /// Gets the tree.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
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
        public IActionResult Create( [FromBody] AddTreeDto dto )
        {
            if ( ModelState.IsValid )
            {
                return Ok( );
            }

            return NotFound( );
        }

        [HttpPut( "{id}" )]
        public IActionResult Edit( int id, [FromBody] EditTreeDto tree )
        {
            return NotFound( );
        }
    }
}