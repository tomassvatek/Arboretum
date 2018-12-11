using Arboretum.AppCore.Models;
using Arboretum.AppCore.Services;
using Arboretum.Web.Config;
using Microsoft.AspNetCore.Mvc;

namespace Arboretum.Web.Controllers
{
    [Produces("application/json")]
    [Route(RestRoute.ControllerRoute)]
    [ApiController]
    public class DendrologiesController : ControllerBase
    {
        private readonly IDendrologyService _dendrologyService;

        public DendrologiesController(IDendrologyService dendrologyService)
        {
            _dendrologyService = dendrologyService;
        }

        /// <summary>Get reduced  dendrologies.</summary>
        /// <param name="reduction">Reduction provides paging information.</param>
        [HttpGet]
        public IActionResult Dendrologies([FromQuery] Reduction reduction)
        {
            var result = _dendrologyService.GetDendrologies(reduction);
            if (result.HasViolations)
            {
                return BadRequest(result.ToString());
            }

            var dendrologies = result.Data;
            return Ok(dendrologies);
        }

        /// <summary>Gets a single dendrology</summary>
        /// <param name="id">dendrology identifier</param>
        [HttpGet(RestRoute.GeDendrologyById)]
        public IActionResult GetDendrologyById(int id)
        {
            var result = _dendrologyService.GetDendrologyById(id);
            if (result.HasViolations)
            {
                return BadRequest(result.ToString());
            }

            var dendrology = result.Data;
            return Ok(dendrology);
        }
    }
}