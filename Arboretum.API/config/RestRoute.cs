using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arboretum.Web.Config
{   
    public static class RestRoute
    {
        public const string ControllerRoute = "api/[controller]";   

        public const string GetTreeById = "{treeId}/provider/{providerId}";
        public const string GetClosestTreeByDendrology = "closest/dendrology/{commonName}"; 
        public const string GetClosestTrees = "closest/{count}";
        public const string UpdateTree = "{id}";

        public const string GeDendrologyById = "{id}";
    }
}
