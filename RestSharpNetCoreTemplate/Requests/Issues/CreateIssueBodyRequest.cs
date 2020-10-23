
namespace RestSharpNetCoreTemplate.Requests.Issues
{

        public class Category
        {
            public string name { get; set; }

        }

        public class Project
        {
            public string name { get; set; }

        }

        public class CreateIssueBodyRequest
        {
            public string summary { get; set; }
            public string description { get; set; }
            public Category category { get; set; }
            public Project project { get; set; }
        }

}
