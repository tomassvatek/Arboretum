using System.Threading.Tasks;
using Arboretum.Core.Models;
using Arboretum.Core.WebServices;
using Microsoft.AspNetCore.Mvc;

namespace Arboretum.API.Controllers
{
    [Produces( "application/json" )]
    [Route( "api/Tree" )]
    public class TreeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTreeAsync( )
        {
            WebApiClient client = new WebApiClient( );
            var data = await client.ReadManyAsync( );
            if ( data == null )
            {
                return BadRequest( );
            }
            return Ok( data );
        }
    }
}