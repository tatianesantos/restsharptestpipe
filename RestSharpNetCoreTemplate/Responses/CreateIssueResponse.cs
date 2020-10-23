using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpNetCoreTemplate.Responses
{
        public class Project
        {
            public int id { get; set; }
            public string name { get; set; }

        }

        public class Category
        {
            public int id { get; set; }
            public string name { get; set; }

        }

        public class Reporter
        {
            public int id { get; set; }
            public string name { get; set; }
            public string email { get; set; }

        }

        public class Status
        {
            public int id { get; set; }
            public string name { get; set; }
            public string label { get; set; }
            public string color { get; set; }

        }

        public class Resolution
        {
            public int id { get; set; }
            public string name { get; set; }
            public string label { get; set; }

        }

        public class ViewState
        {
            public int id { get; set; }
            public string name { get; set; }
            public string label { get; set; }

        }

        public class Priority
        {
            public int id { get; set; }
            public string name { get; set; }
            public string label { get; set; }

        }

        public class Severity
        {
            public int id { get; set; }
            public string name { get; set; }
            public string label { get; set; }

        }

        public class Reproducibility
        {
            public int id { get; set; }
            public string name { get; set; }
            public string label { get; set; }

        }

        public class User
        {
            public int id { get; set; }
            public string name { get; set; }
            public string email { get; set; }

        }

        public class Type
        {
            public int id { get; set; }
            public string name { get; set; }

        }

        public class History
        {
            public DateTime created_at { get; set; }
            public User user { get; set; }
            public Type type { get; set; }
            public string message { get; set; }

        }

        public class Issue
    {
            public int id { get; set; }
            public string summary { get; set; }
            public string description { get; set; }
            public Project project { get; set; }
            public Category category { get; set; }
            public Reporter reporter { get; set; }
            public Status status { get; set; }
            public Resolution resolution { get; set; }
            public ViewState view_state { get; set; }
            public Priority priority { get; set; }
            public Severity severity { get; set; }
            public Reproducibility reproducibility { get; set; }
            public bool sticky { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public List<History> history { get; set; }

        }

    public class CreateIssueResponse
    {
        public Issue issue { get; set; }

    }

}
