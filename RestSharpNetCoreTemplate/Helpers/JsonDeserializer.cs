using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using RestSharpNetCoreTemplate.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpNetCoreTemplate.Helpers
{
    public class JsonDeserializer
    {
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }

        public T Deserialize<T>(Task<IRestResponse> response)
        {
            return JsonConvert.DeserializeObject<T>(response.Result.Content);
        }


    }
}
