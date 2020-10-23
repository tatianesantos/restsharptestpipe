using MongoDB.Driver.GeoJsonObjectModel;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharpNetCoreTemplate.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpNetCoreTemplate.Bases
{
    public class RequestBase
    {
        #region Parameters
        protected object jsonBody = null;

        protected string url = JsonBuilder.ReturnParameterAppSettings("URL");

        protected string requestService = null;

        protected Method method;

        protected bool httpBasicAuthenticator = false;

        protected bool ntlmAuthenticator = false;

        protected IDictionary<string, string> headers = new Dictionary<string, string>()
        {
            //Dicionário de headeres deve ser iniciado com os headers comuns a todos os métodos da API
            {"Content-Type", "application/json"},
            //{"Authorization", "oStEP4yy1yKIwKchx8ExX7AO4sa5nbSy"},
        };
               
        protected IDictionary<string, string> cookies = new Dictionary<string, string>()
        {
            //Dicionário de cookies deve ser iniciado com os headers comuns à todas os métodos da API
        };

        protected IDictionary<string, string> parameters = new Dictionary<string, string>();

 
        protected bool parameterTypeIsUrlSegment = true;

        #endregion

        #region Actions
         public Task<IRestResponse> ExecuteRequest()
        {

            Task<IRestResponse> response = RestSharpHelpers.ExecuteRequest(url, requestService, method, headers, cookies, parameters, parameterTypeIsUrlSegment, jsonBody, httpBasicAuthenticator, ntlmAuthenticator);
            ExtentReportHelpers.AddTestInfo(url, requestService, method.ToString(), headers, cookies, parameters, jsonBody, httpBasicAuthenticator, ntlmAuthenticator, response);

            return response;
        }


         public void RemoveHeader(string header)
        {
            headers.Remove(header);           
        }

        public void RemoveCookie(string cookie)
        {
            cookies.Remove(cookie);
        }

        public void RemoveParameter(string parameter)
        {
            parameters.Remove(parameter);
        }

        public void SetMethod(Method method)
        {
            this.method = method;
        }
        #endregion
    }
}
