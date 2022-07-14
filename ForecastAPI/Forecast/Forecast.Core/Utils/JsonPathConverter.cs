using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Forecast.Core.Utils
{
    /// <summary>
    /// Custom util to map JSON nested objects
    /// </summary>
    public class JsonPathConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType,
                                    object existingValue, JsonSerializer serializer)
        {
            try
            {
                JObject sourceObject = JObject.Load(reader);
                object targetObject = Activator.CreateInstance(objectType);

                foreach (PropertyInfo property in objectType.GetProperties()
                                                        .Where(p => p.CanRead && p.CanWrite))
                {
                    JsonPropertyAttribute attribute = property.GetCustomAttributes(true)
                                                    .OfType<JsonPropertyAttribute>()
                                                    .FirstOrDefault();

                    string jsonPath = (attribute != null  ?attribute.PropertyName : property.Name);
                    JToken token = null;
                    if (!string.IsNullOrEmpty(jsonPath))
                    {
                        token = sourceObject.SelectToken(jsonPath);
                        token ??= DecryptToken(sourceObject, jsonPath);
                    }
                    if (token != null && token.Type != JTokenType.Null)
                    {
                        object value = token.ToObject(property.PropertyType, serializer);
                        property.SetValue(targetObject, value, null);
                    }
                   
                }
                if (targetObject != null)
                    return targetObject;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
            return string.Empty;
        }

        public override bool CanConvert(Type objectType)
        {
            return false;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value,
                                       JsonSerializer serializer)
        {
        }

        private static JToken DecryptToken(JObject jObject, string path)
        {
            JToken jToken = null;
            try
            {
                string firstElement = path.Split(".")[0];
                if (path.Contains('0'))
                {
                    jToken = jObject[firstElement][0];
                    path = path.Remove(0, path.IndexOf('0') + 2);
                }
                if ((jToken != null) && (path.Split(".").Any()))
                {
                    foreach (string property in path.Split("."))
                    {
                        jToken = jToken[property];
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
            return jToken;
        }

    }
}
