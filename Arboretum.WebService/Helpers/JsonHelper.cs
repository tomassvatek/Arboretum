using System;
using Newtonsoft.Json;

namespace Arboretum.WebService.Helpers
{
    public static class JsonHelper<T>
    {
        public static T Deserialize(string jsonToDeserialize)
        {
            try
            {   
                var trees = JsonConvert.DeserializeObject<T>(jsonToDeserialize);
                return trees;
            }

            catch (Exception)
            {
                return default(T);
            }
        }
    }
}