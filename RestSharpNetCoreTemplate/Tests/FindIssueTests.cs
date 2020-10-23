using System;
using System.Threading.Tasks;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Helpers;
using RestSharpNetCoreTemplate.Requests.Issues;
using RestSharpNetCoreTemplate.Steps;
using Xunit;
using Xunit.Abstractions;

namespace RestSharpNetCoreTemplate.Tests
{
    [Collection("Our Test Collection #1")]
    public class FindIssueTests : XunitContextBase, IClassFixture<TestBase>, IDisposable
    {

        #region parametersandinstance
        ParametersHelpers parameters = new ParametersHelpers();
        CreateToken tokenNumber = new CreateToken();
        private string status, message, stacktrace;
        string token;
        string issueId = "1";
        string method = "GET";
        #endregion parametersandinstance

        #region constructor
        public FindIssueTests(ITestOutputHelper output) : base(output)
        {
            XunitContext.EnableExceptionCapture();
            ExtentReportHelpers.AddTest(Context.MethodName, Context.ClassName);
            tokenNumber.GenerateToken(out token);
        }
        #endregion constructor

        #region tests
        [Fact]
        public void FindIssue()
        {
            //Arrange
            FindIssueRequest findIssueRequest = new FindIssueRequest(issueId, token, method);
            //Act
            Task<IRestResponse> responseIssue = findIssueRequest.ExecuteRequest();
            //Assert
            Assert.Equal(parameters.StatusCodeSucess(), responseIssue.Result.StatusCode.ToString());

        }

        [Fact]
        public void FindIssueTeste()
        {
            //Arrange
            FindIssueRequest findIssueRequest = new FindIssueRequest(issueId, token, method);
            //Act
            Task<IRestResponse> responseIssueTeste = findIssueRequest.ExecuteRequest();
            //Assert
            Assert.Equal(parameters.StatusCodeSucess(), responseIssueTeste.Result.StatusCode.ToString());
        }
        #endregion tests

        #region teardown
        public override void Dispose()
        {
            if (Context.TestException != null)
            {
                stacktrace = Context.TestException.StackTrace; 
                message = Context.TestException.Message; 
                status = "Failed";
            }
            ExtentReportHelpers.AddTestResult(status, message, stacktrace);
            base.Dispose();

        }
        #endregion teardown
    }
}
