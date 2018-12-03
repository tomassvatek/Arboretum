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