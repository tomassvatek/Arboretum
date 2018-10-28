using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arboretum.API.config
{   
    public static class RestRoute
    {
        public const string ControllerRoute = "api/[controller]";   

        public const string GetTreeById = "{id}";
        public const string GetNumberTrees = "count/{number}";
        public const string UpdateTree = "{id}";
    }
}
