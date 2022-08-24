using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RestSharpDemo;
using RestSharpDemo.Models.Request;
using System.Net;
using RestSharpDemo.Models;
using AventStack.ExtentReports;

namespace ApiTests
{
    [TestClass]
    public class SmokeTest
    {
        public TestContext TestContext { get; set; }
        public HttpStatusCode statusCode;
        private const string BASE_URL = "https://reqres.in/";

        [ClassInitialize]
        public static void SetupReport(TestContext testContext)
        {
            var dir = testContext.TestRunDirectory;
            Reporter.SetupReport(dir, "SmokeTest", "Smoke Test Result");
        }

        [TestInitialize]
        public void SetupTest()
        {
            Reporter.CreateTest(TestContext.TestName);
        }

        [TestCleanup]
        public void TearDownTest()
        {
            var testStatus = TestContext.CurrentTestOutcome;
            Status status;
            switch (testStatus)
            {
                case UnitTestOutcome.Failed:
                    status = Status.Fail;
                    Reporter.TestStatus(status.ToString());
                    break;
                case UnitTestOutcome.Inconclusive:
                    break;
                case UnitTestOutcome.Passed:
                    status = Status.Pass;
                    Reporter.TestStatus(status.ToString());
                    break;
                case UnitTestOutcome.InProgress:
                    break;
                case UnitTestOutcome.Error:
                    break;
                case UnitTestOutcome.Timeout:
                    break;
                case UnitTestOutcome.Aborted:
                    break;
                case UnitTestOutcome.Unknown:
                    break;
                case UnitTestOutcome.NotRunnable:
                    break;
            }
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            Reporter.FlushReport();
        }

        [TestMethod]
        public void GetListOfUsers()
        {
            var api = new Demo();
            var response = api.GetUsers(BASE_URL);
            var content = HandleContent.GetContent<Users>(response);
            Assert.AreEqual(2, content.Page);
            string message = String.Format("{0} is equal to 2", content.Page);
            Reporter.LogToReport(Status.Pass, message);
        }

        //[DeploymentItem("TestData\\CreateUser.csv"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "CreateUser.csv", "CreateUser#csv", DataAccessMethod.Sequential)]
        [DeploymentItem("TestData")]
        [TestMethod]
        public void CreateNewUserTest()
        {
            var payload = HandleContent.ParseJson<CreateUserRequest>("CreateUser.json");

            var api = new Demo();
            var response = api.CreateNewUser(BASE_URL, payload);
            statusCode = response.StatusCode;
            var code = (int)statusCode;
            Assert.AreEqual(201, code);
            Reporter.LogToReport(Status.Pass, "201 response code is received");

            var userContent = HandleContent.GetContent<CreateUserRes>(response);
            Assert.AreEqual(payload.Name, userContent.Name);
            string message = String.Format("{0} is equal to {1}", userContent.Name, payload.Name);
            Reporter.LogToReport(Status.Pass, message);
        }
    }
}
