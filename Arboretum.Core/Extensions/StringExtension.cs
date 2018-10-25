using System;
using System.Collections.Generic;
using Arboretum.Core.Entities;
using Arboretum.Core.Helpers.DataProviders;
using Arboretum.Core.Models;
using Arboretum.Core.Services.Models;
using Newtonsoft.Json;

namespace Arboretum.Core.Extensions
{
    public static class StringExtension
    {
        public static List<Tree> DeserializeTrees( this string json )
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

        public static List<RestDataProvider> DeserializeProviders( this string json )
        {
            try
            {
                return JsonConvert.DeserializeObject<List<RestDataProvider>>( json );
            }

            catch ( Exception )
            {
                return null;
            }
        }
    }
}
