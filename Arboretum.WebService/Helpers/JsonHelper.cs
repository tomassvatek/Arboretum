using System;
using System.Collections.Generic;
using Arboretum.AppCore.Models;
using Arboretum.WebService.Providers.Interfaces;
using Arboretum.WebService.Providers.SPK;
using Newtonsoft.Json;

namespace Arboretum.WebService.Helpers
{
    public static class JsonHelper<T> where T : ITreeDataModel
    {
        public static List<T> DeserializeTrees( string jsonToDeserialize )
        {
            try
            {
                var trees = JsonConvert.DeserializeObject<List<T>>(jsonToDeserialize);
                return trees;
            }

            catch ( Exception e )
            {
                return null;
            }
        }

        public static T DeserializeTree(string jsonToDeserialize)
        {
            try
            {
                var tree = JsonConvert.DeserializeObject<T>(jsonToDeserialize);
                return tree;
            }
            catch (Exception exception)
            {
                //TODO: Handle exception consitently.
                throw new ArgumentException();
            }
        }
    }
}