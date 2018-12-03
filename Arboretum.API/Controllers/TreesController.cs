using System.Threading.Tasks;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Services;
using Arboretum.Common.Enums;
using Arboretum.Web.Config;
using Arboretum.Web.Mappers;
using Arboretum.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Arboretum.Web.Controllers
{
    [Produces("application/json")]
    [Route(RestRoute.ControllerRoute)]
    [ApiController]
    public class TreesController : ControllerBase
    {
        private readonly ITreeService _treeService;

        public TreesController(ITreeService treeService)
        {
            _treeService = treeService;
        }

        /// <summary>
        /// Gets the trees.
        /// </summary>
        /// <param name="visibleRegion">The visible region.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTrees([FromQuery] VisibleRegionViewModel visibleRegion)
        {
            var result = await _treeService.GetTreesAsync(visibleRegion);
            if (result.HasViolations)
            {
                return BadRequest(result.ToString());
            }

            var trees = result.Data;
            var vm = ViewModelMapper.MapTreeToViewModel(trees);

            return Ok(vm);
        }

        /// <summary>
        /// Gets the closest trees.
        /// </summary>
        /// <param name="visibleRegion">The visible region.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        [HttpGet(RestRoute.GetClosestTrees)]
        public async Task<IActionResult> GetClosestTrees([FromQuery] VisibleRegionViewModel visibleRegion, double latitude,
            double longitude, int count)
        {
            //visibleRegion.LatitudeMax = 49.797345;
            //visibleRegion.LatitudeMin = 49.795380;
            //visibleRegion.LongitudeMax = 12.634210;
            //visibleRegion.LongitudeMin = 12.633100;

            var result = await _treeService.GetClosestTreesAsync(visibleRegion, latitude, longitude, count);
            if (result.HasViolations)
            {
                return BadRequest(result.ToString());
            }

            var closestTrees = result.Data;
            var vm = ViewModelMapper.MapTreeToViewModel(closestTrees);

            return Ok(vm);  
        }

    
        [HttpGet(RestRoute.GetTreeById)]
        public async Task<IActionResult> GetTreeById(int treeId, ProviderName providerId)
        {
            var result = await _treeService.GetTreeById(treeId, providerId);
            if (result.HasViolations)
            {
                return BadRequest(result.ToString());
            }

            var tree = result.Data;
            var vm = ViewModelMapper.MapTreeToViewModel(tree);
            return Ok(vm);
        }

        //TODO: Method bellow do same work. Merge these two!
        [HttpGet(RestRoute.GetClosestTreeByDendrology)]
        public async Task<IActionResult> GetClosestTreeByDendrology([FromQuery] VisibleRegionViewModel region, double latitude, double longitude, string commonName)      
        {
            var result = await _treeService.GetClosestTree(region, latitude, longitude, commonName);
            if (result.HasViolations)
            {
                return BadRequest();
            }

            var closestTree = result.Data;
            return Ok(closestTree);
        }

        //[HttpGet(RestRoute.GetClosestTree)]
        //public async Task<IActionResult> GetClosestTreeAsync([FromQuery] VisibleRegionViewModel region, double latitude, double longitude, string commonName)
        //{
        //    var result = await _treeService.GetClosestTree(region, latitude, longitude, commonName);
        //    if (result.HasViolations)
        //    {
        //        return BadRequest();
        //    }

        //    var closestTree = result.Data;
        //    return Ok(closestTree);
        //}

        /// <summary>
        /// Creates the tree.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateTree([FromQuery] CreateTreeViewModel viewModel)
        {
            var domainTree = new Tree()
            {
                Note = viewModel.Note, Latitude = viewModel.Latitude, Longitude = viewModel.Longitude,
                Dendrology = new Dendrology() {Id = viewModel.DendrologyId}
            };

            var result = _treeService.CreateTree(domainTree);
            if (result.HasViolations)
            {
                return BadRequest(result.ToString());
            }

            //TODO: return resource
            var createdTree = result.Data;

            return NoContent();
        }

        /// <summary>
        /// Edits the tree.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        [HttpPut(RestRoute.UpdateTree)]
        public IActionResult EditTree(int id, [FromQuery] EditTreeViewModel viewModel)
        {
            //TODO: Move to static method
            var domainTree = new Tree
            {
                Age = viewModel.Age,
                CrownSize = viewModel.CrownSize,
                Height = viewModel.Height,
                Note = viewModel.Note
            };

            var result = _treeService.UpdateTree(id, domainTree);
            if (result.HasViolations)
            {
                return BadRequest(result.ToString());
            }

            return NoContent();
        }
    }
}