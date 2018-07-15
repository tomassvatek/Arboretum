using System;
using System.Linq;
using System.Threading.Tasks;
using Arboretum.API.Viewmodels;
using Arboretum.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Arboretum.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Tree")]
    public class TreeController : ControllerBase
    {
        private readonly ITreeRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public TreeController(ITreeRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets the trees by viewport.
        /// </summary>
        /// <param name="viewport">The viewport.</param>
        /// <returns></returns>
        //[HttpGet]
        //public async Task<IActionResult> GetTreesAsync([FromQuery] MapViewportVm viewport)
        //{
        //    MapViewport mapViewport = new MapViewport(viewport.LatitudeMin, viewport.LatitudeMax, viewport.LongitudeMin, viewport.LongitudeMax);
        //    var trees = await _repository.GetTrees(mapViewport);
        //    if (trees == null)
        //    {
        //        return BadRequest();
        //    }
        //    var vm = trees.Select(e => new TreeInfoWindowVm
        //    {
        //        Id = e.Id,
        //        SpeciesCommonName = e.SpeciesCommonName
        //    }).ToList();

        //    return Ok(vm);
        //}


        //[HttpGet]
        //public IActionResult GetTrees(QuizOption option, [FromQuery] MapViewport viewport)
        //{
        //    throw new NotImplementedException();
        //}

        [HttpGet]
        public IActionResult GetTree(int id)
        {
            var tree = _repository.GetTreeById(id);
            if (tree == null)
            {
                return NotFound();
            }
            return Ok(tree);
        }
    }
}