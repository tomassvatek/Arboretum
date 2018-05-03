using System.Threading.Tasks;
using Arboretum.Core.Models;
using Arboretum.Core.Models.Locations;
using Arboretum.Core.WebServices;
using Arboretum.Core.WebServices.Providers;
using Microsoft.AspNetCore.Mvc;

namespace Arboretum.API.Controllers
{
    [Produces( "application/json" )]
    [Route( "api/Tree" )]
    public class TreeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTreeAsync( [FromQuery] MapViewport viewport )
        {
            WebApiClient client = new WebApiClient( new SPKProvider( ) );
            var data = await client.ReadManyAsync( );
            if ( data == null )
            {
                return BadRequest( );
            }
            return Ok( data );
        }
    }
}