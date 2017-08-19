using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSocketApplication.Extensions
{
    public static class JsonExtension
    {
        public static readonly string schemaJson = @"{
                         'status': {'type': 'string'},
                         'error': {'type': 'string'},
                         'code': {'type': 'string'}
                        }";

        public static T TryParseJson<T>(this string json) where T : new()
        {


            JSchema parsedSchema = JSchema.Parse(schemaJson);
            try
            {

                JObject jObject = JObject.Parse(json);
                return jObject.IsValid(parsedSchema) ?
                    JsonConvert.DeserializeObject<T>(json) : default(T);
            }
            catch
            {
                return default(T);
            }

        }
    }
}
