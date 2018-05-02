using System;
using System.Collections.Generic;
using Arboretum.Core.Models;
using Newtonsoft.Json;

namespace Arboretum.Core.Extensions
{
    public class JsonExtension
    {
        public static List<Tree> DeserializeJsonTrees( string json )
        {
            var trees = JsonConvert.DeserializeObject<List<Tree>>( json );
            return trees;
        }
    }
}
