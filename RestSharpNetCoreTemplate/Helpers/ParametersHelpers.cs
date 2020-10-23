using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;

namespace RestSharpNetCoreTemplate.Helpers
{
    public class ParametersHelpers : RequestBase
    {
        public string StatusCodeSucess()
        {
            return "OK";
        }
        public string[] ListVariablesExtentReport()
        {
            string[] variables = null;
            string stacktrace = "";
            string message = "Sucess";
            string status = "Passed";
            variables[0] = status;
            variables[1] = message;
            variables[2] = stacktrace;
            return variables;
        }
        public RestSharp.Method DefinitionMethodRequest(string method)
        {
            RestSharp.Method methodReturn = RestSharp.Method.GET;
            switch (method)
            {
                case "POST":
                    methodReturn = RestSharp.Method.POST;
                    break;
                case "PUT":
                    methodReturn = RestSharp.Method.PUT;
                    break;
                case "DELETE":
                    methodReturn = RestSharp.Method.DELETE;
                    break;
                case "PATCH":
                    methodReturn = RestSharp.Method.POST;
                    break;
            }

            return methodReturn;
        }
    }
}
