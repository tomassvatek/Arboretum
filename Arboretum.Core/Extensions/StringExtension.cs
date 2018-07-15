using System;
using System.Collections.Generic;
using Arboretum.Core.Models.Entities;
using Newtonsoft.Json;

namespace Arboretum.Core.Extensions
{
    public static class StringExtension
    {   
        public static List<Tree> DeserializeTree( this string json )
        {
            try
            {
                var trees = JsonConvert.DeserializeObject<List<Tree>>( json );
                return trees;
            }
            catch ( Exception )
            {
                return null;
            }
        }
    }
}
