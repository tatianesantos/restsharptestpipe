using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace RestSharpNetCoreTemplate.Helpers
{
    public class RestSharpHelpers
    {
        public static async Task<IRestResponse> ExecuteRequest(string url,
                                                     string requestService,
                                                     Method method,
                                                     IDictionary<string, string> headers,
                                                     IDictionary<string, string> cookies,
                                                     IDictionary<string, string> parameters,
                                                     bool parameterTypeIsUrlSegment,
                                                     object jsonBody,
                                                     bool httpBasicAuthenticator,
                                                     bool ntlmAuthenticator)
        {
            RestRequest request = new RestRequest(requestService, method);

            foreach (var header in headers)
            {
                request.AddParameter(header.Key, header.Value, ParameterType.HttpHeader);
            }

            foreach (var cookie in cookies)
            {
                request.AddParameter(cookie.Key, cookie.Value, ParameterType.Cookie);
            }

            foreach (var parameter in parameters)
            {
                if (parameterTypeIsUrlSegment)
                {
                    request.AddParameter(parameter.Key, parameter.Value, ParameterType.UrlSegment);
                }
                else
                {
                    request.AddParameter(parameter.Key, parameter.Value);
                }
            }


            request.JsonSerializer = new JsonSerializer();

            if (jsonBody != null)
            {
                JsonSerializer jsonSerializer = new JsonSerializer();

                string jsonsSerializer = jsonSerializer.Serialize(jsonBody);

                    if (GeneralHelpers.IsAJsonArray(jsonsSerializer))
                    {
                        request.AddJsonBody(new JArray(jsonSerializer));
                    }
                    else
                    {
                        request.AddJsonBody(JsonConvert.DeserializeObject<JObject>(jsonsSerializer));
                    }
            }
            
            RestClient client = new RestClient(url);
            //client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true; //utilizar url interna do gateway
            //client.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Revalidate); //limpar cache

            if (httpBasicAuthenticator)
            {
                //client.PreAuthenticate = true; //caso seja necessária pré atenticação
                client.Authenticator = new HttpBasicAuthenticator(JsonBuilder.ReturnParameterAppSettings("AUTHENTICATOR_USER"), JsonBuilder.ReturnParameterAppSettings("AUTHENTICATOR_PASSWORD"));
            }

            if (ntlmAuthenticator)
            {
                client.Authenticator = new NtlmAuthenticator(JsonBuilder.ReturnParameterAppSettings("AUTHENTICATOR_USER"), JsonBuilder.ReturnParameterAppSettings("AUTHENTICATOR_PASSWORD"));
            }

            return await client.ExecuteAsync(request);
        }

 

        public static XmlNodeList getElementXml(IRestResponse<dynamic> response, string elementTag)
        {
            XmlDocument responseXml = new XmlDocument();
            responseXml.LoadXml(response.Content);

            return responseXml.GetElementsByTagName(elementTag);
        }

        public static IRestResponse<dynamic> ExecuteSoapRequest(string url,
                                                            IDictionary<string, string> headers,
                                                            IDictionary<string, string> cookies,
                                                            string bodyXml,
                                                            bool httpBasicAuthenticator,
                                                            bool ntlmAuthenticator)
        {
            RestRequest request = new RestRequest(url, Method.POST);
            request.RequestFormat = RestSharp.DataFormat.Xml;

            foreach (var header in headers)
            {
                request.AddParameter(header.Key, header.Value, ParameterType.HttpHeader);
            }

            foreach (var cookie in cookies)
            {
                request.AddParameter(cookie.Key, cookie.Value, ParameterType.Cookie);
            }

            if (bodyXml != null)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(bodyXml);
                request.AddParameter("text/xml", xmlDoc.OuterXml, ParameterType.RequestBody);
            }

            RestClient client = new RestClient(url);

            if (httpBasicAuthenticator)
            {

                client.Authenticator = new HttpBasicAuthenticator(JsonBuilder.ReturnParameterAppSettings("AUTHENTICATOR_USER"), JsonBuilder.ReturnParameterAppSettings("AUTHENTICATOR_PASSWORD"));
            }

            if (ntlmAuthenticator)
            {
                client.Authenticator = new NtlmAuthenticator(JsonBuilder.ReturnParameterAppSettings("AUTHENTICATOR_USER"), JsonBuilder.ReturnParameterAppSettings("AUTHENTICATOR_PASSWORD"));
            }

            return client.Execute<dynamic>(request);
        }
    }
}
