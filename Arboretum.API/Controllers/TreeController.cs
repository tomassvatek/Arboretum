using System;
using System.Linq;
using System.Threading.Tasks;
using Arboretum.Core.Repositories;
using Arboretum.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Arboretum.API.Controllers
{
    [Produces( "application/json" )]
    [Route( "api/Tree" )]
    public class TreeController : ControllerBase
    {
        private readonly ITreeService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public TreeController( ITreeService service )
        {
            _service = service;
        }

        /// <summary>
        /// Gets the trees by viewport.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetTrees( )
        {
            var trees = _service.GetTrees();
            return Ok( trees );
        }


        //[HttpGet]
        //public IActionResult GetTrees(QuizOption option, [FromQuery] MapViewport viewport)
        //{
        //    throw new NotImplementedException();
        //}

        [HttpGet]
        public IActionResult GetTree( int id )
        {
            var tree = _service.GetTreeById(id);

            if ( tree == null )
            {
                return NotFound( );
            }

            return Ok( tree );
        }
    }
}