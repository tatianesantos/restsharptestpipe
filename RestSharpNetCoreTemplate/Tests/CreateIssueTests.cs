using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.DefaultParameters;
using RestSharpNetCoreTemplate.Helpers;
using RestSharpNetCoreTemplate.Requests.Issues;
using RestSharpNetCoreTemplate.Responses;
using RestSharpNetCoreTemplate.Steps;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RestSharpNetCoreTemplate.Tests
{
    [Collection("Our Test Collection #1")] //por default o xunit executa em paralelo as classes de testes, para que seja executado sem paralelismo este decorador deve ser inserido acima de todas as classes que não podem ser executadas de forma paralela
    public class CreateIssueTests : XunitContextBase, IClassFixture<TestBase>, IDisposable
    {

        #region parametersandinstance
        CreateToken tokenNumber = new CreateToken();
        IssueDefaultParameters issueDefaultParameters = new IssueDefaultParameters();
        CreateIssueResponse createIssueResponse = new CreateIssueResponse();
        JsonDeserializer jsonDeserializer = new JsonDeserializer();
        string method = "POST";
        string statusEsperado = "Created";
        private string status, message, stacktrace;
        string token;
        //issueDefaultParameters.description = "Teste Inserção Parâmetro"; //precisar inserir informação diferente da defaul
        //string variable = Environment.GetEnvironmentVariable("\\nomedavariaveldeambiente"); //retorna uma variável de ambiente criada
        #endregion parametersandinstance

        #region constructor
        public CreateIssueTests(ITestOutputHelper output) : base(output)
        {
            XunitContext.EnableExceptionCapture();
            ExtentReportHelpers.AddTest(Context.MethodName, Context.ClassName);
            tokenNumber.GenerateToken(out token); //váriaveis out no lugar de array

        }
        #endregion constructor

        [Fact]
        public void CreateIssue()
        {
            //Arrange
            CreateIssueRequest createIssueRequest = new CreateIssueRequest(token, method, issueDefaultParameters.category, issueDefaultParameters.summary, issueDefaultParameters.description, issueDefaultParameters.projectName);

            //Act
            Task<IRestResponse> responseCreate = createIssueRequest.ExecuteRequest();

            //Assert
            createIssueResponse = jsonDeserializer.Deserialize<CreateIssueResponse>(responseCreate);
            string nameCategory = createIssueResponse.issue.category.name;
            Assert.Equal(statusEsperado, responseCreate.Result.StatusCode.ToString());
            Assert.Equal(issueDefaultParameters.category, nameCategory);
        }

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
