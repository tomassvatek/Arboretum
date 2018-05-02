using System.Threading.Tasks;
using Arboretum.Core.WebServices;
using Microsoft.AspNetCore.Mvc;

namespace Arboretum.API.Controllers
{
    [Produces( "application/json" )]
    [Route( "api/Tree" )]
    public class TreeController : ControllerBase
    {
        public async Task<IActionResult> GetTreeAsync( )
        {
            WebApiClient client = new WebApiClient( );
            string data = await client.ReadManyAsync( );
            if ( data == null )
            {
                return BadRequest( );
            }
            return Ok( data );
        }
    }
}