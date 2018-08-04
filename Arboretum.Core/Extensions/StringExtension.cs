using System;
using System.Collections.Generic;
using Arboretum.Core.Models;
using Arboretum.Core.WebServices;
using Newtonsoft.Json;

namespace Arboretum.Core.Extensions
{
    public static class StringExtension
    {
        public static List<Tree> DeserializeTree( this string json )
        {
            try
            {
                var dto = JsonConvert.DeserializeObject<List<TreeDto>>( json );
                var trees = new List<Tree>();

                if ( trees != null )
                {
                    foreach ( var item in dto )
                    {
                        var tree = new Tree()
                        {
                            Id = item.Id,
                            Latitude = item.Latitude,
                            Longitude = item.Longitude,
                            Dendrology = new Dendrology(item.CommonName, item.ScientificName)
                        };

                        trees.Add( tree );
                    }
                }

                return trees;
            }

            catch ( Exception )
            {
                return null;
            }
        }
    }
}
