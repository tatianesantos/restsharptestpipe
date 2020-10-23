using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpNetCoreTemplate.DefaultParameters
{
    public class IssueDefaultParameters
    {
        public string category { get; set; } = "General";
        public string summary { get; set; } = "TesteApi2";
        public string description { get; set; } = "Testes Apis 2";
        public string projectName { get; set; } = "Treinamento API";
    }
}
