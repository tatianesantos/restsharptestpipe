using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Helpers;


namespace RestSharpNetCoreTemplate.Requests.Issues
{
    public class CreateIssueRequest : RequestBase
    {
        ParametersHelpers parametersHelpers = new ParametersHelpers();
        public CreateIssueRequest(string token, string methodTest, string category, string sumary, string desc, string projname)
        {
            url = JsonBuilder.ReturnParameterAppSettings("URL");
            requestService = "/api/rest/issues";
            method = parametersHelpers.DefinitionMethodRequest(methodTest);
            headers.Add("Authorization", token);

            switch (methodTest)
            {
                case "POST":
                    jsonBody = setJsonBody(category, sumary, desc, projname);
                    break;
            }

        }
       public object setJsonBody(string category, string sumary, string desc, string projname)
        {
         object json = new CreateIssueBodyRequest
         {
                category = new Category() { name = category },
                summary = sumary,
                description = desc,
                project = new Project() { name = projname },
            };

            return json;

        }
    }
}
