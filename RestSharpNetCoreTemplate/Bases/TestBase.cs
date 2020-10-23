using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using RestSharpNetCoreTemplate.Helpers;
using AventStack.ExtentReports;

namespace RestSharpNetCoreTemplate.Bases
{
    public class TestBase : IDisposable
    {

        public TestBase()
        {
             ExtentReportHelpers.CreateReport();
        }
 
        public void Dispose()
        {
            ExtentReportHelpers.GenerateReport();
        }

    }

}
