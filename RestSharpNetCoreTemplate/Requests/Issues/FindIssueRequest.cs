using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RestSharpNetCoreTemplate.Requests.Issues
{
    public class FindIssueRequest : RequestBase
    {
        ParametersHelpers parametersHelpers = new ParametersHelpers();
        public FindIssueRequest(string issueId, string token, string methodtest)
        {
            url = JsonBuilder.ReturnParameterAppSettings("URL");
            requestService = "/api/rest/issues/{issueId}";
            method = parametersHelpers.DefinitionMethodRequest(methodtest);
            parameters.Add("issueId", issueId);
            //Implementação como se o token fosse chamada apenas nesta api
            headers.Add("Authorization", token);
        }

    }
}
