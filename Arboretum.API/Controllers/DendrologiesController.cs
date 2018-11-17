using Arboretum.AppCore.Services;
using Arboretum.API.Config;
using Microsoft.AspNetCore.Mvc;

namespace Arboretum.API.Controllers
{
    [Produces("application/json")]
    [Route(RestRoute.ControllerRoute)]
    public class DendrologiesController : ControllerBase
    {
        private readonly IDendrologyService _dendrologyService;

        public DendrologiesController(IDendrologyService dendrologyService)
        {
            _dendrologyService = dendrologyService;
        }

        [HttpGet]
        public IActionResult Dendrologies()
        {
            var result = _dendrologyService.GetDendrologies();
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