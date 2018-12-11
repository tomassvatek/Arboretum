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
        /// Gets the trees by the visible region.
        /// </summary>
        /// <param name="visibleRegion">The visible region.</param>
        /// <returns></returns>
        [HttpGet] // api/trees
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
        /// <param name="latitude">Current user location - latitude.</param>
        /// <param name="longitude">Current user location - longitude.</param>
        /// <param name="count">Trees count.</param>
        /// <returns></returns>
        [HttpGet(RestRoute.GetClosestTrees)]
        public async Task<IActionResult> GetClosestTrees([FromQuery] VisibleRegionViewModel visibleRegion, double latitude,
            double longitude, int count)
        {
            var result = await _treeService.GetClosestTreesAsync(visibleRegion, latitude, longitude, count);
            if (result.HasViolations)
            {
                return BadRequest(result.ToString());
            }

            var closestTrees = result.Data;
            var vm = ViewModelMapper.MapTreeToViewModel(closestTrees);

            return Ok(vm);  
        }


        /// <summary>
        /// Gets the tree by identifier.
        /// </summary>
        /// <param name="treeId">The tree identifier.</param>
        /// <param name="providerId">The provider identifier.</param>
        /// <returns></returns>
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

        /// <summary>Gets the closest tree by dendrology name.</summary>
        /// <param name="region">The region.</param>
        /// <param name="latitude">Current user location - latitude.</param>
        /// <param name="longitude">Current user location - longitude.</param>
        /// <param name="commonName">Czech dendrology name.</param>
        /// <returns>Tree</returns>
        [HttpGet(RestRoute.GetClosestTreeByDendrology)]
        public async Task<IActionResult> GetClosestTreeByDendrology([FromQuery] VisibleRegionViewModel region, double latitude, double longitude, string commonName)      
        {
            var result = await _treeService.GetClosestTree(region, latitude, longitude, commonName);
            if (result.HasViolations)
            {
                return BadRequest();
            }

            var closestTree = result.Data;
            var vm = ViewModelMapper.MapTreeToViewModel(closestTree);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the tree.
        /// </summary>
        /// <param name="viewModel">Tree to add.</param>
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
        /// <param name="id">The tree identifier that will be edit.</param>
        /// <param name="viewModel">The updated tree data.</param>
        /// <returns></returns>
        [HttpPut(RestRoute.UpdateTree)]
        public IActionResult EditTree(int id, [FromQuery] EditTreeViewModel viewModel)
        {
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