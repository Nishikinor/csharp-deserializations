using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonHelper
{
    public static class JsonSerializeHelper
    {
        private static readonly JsonSerializerSettings _jsonserializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All, // unsafe configuration
            ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
        };

        public static string Serialize<T>(T data)
        {
            return JsonConvert.SerializeObject(data, _jsonserializerSettings);
        }

        public static string Serialize(object data)
        {
            return JsonConvert.SerializeObject(data, _jsonserializerSettings);
        }

        public static bool TryDeserialize<T> (string json, out T obj)
        {
            obj = default(T);
            if (string.IsNullOrWhiteSpace(json)) return false;
            try
            {
                obj = JsonConvert.DeserializeObject<T>(json, _jsonserializerSettings);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static T Deserialize<T> (string json)
        {
            if (string.IsNullOrWhiteSpace(json)) return default(T);
            return JsonConvert.DeserializeObject<T>(json, _jsonserializerSettings);
        }

        public static T Deserialize<T> (object json)
        {
            string request = json.ToString();
            return Deserialize<T>(request);
        }
    }
}
