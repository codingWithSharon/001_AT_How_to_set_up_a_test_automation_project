using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _001_AT_How_to_set_up_a_test_automation_project.APITests;

namespace _001_AT_How_to_set_up_a_test_automation_project.APITests.TestFixtures.HappyFlow
{
    public class AutomationExerciseAPITests
    {
        [Parallelizable(ParallelScope.Fixtures)]

        [TestFixture, Category("KvkApiTestHappyFlow")]

        public class KvkTests : ApiSetup
        {
            [Test]
            public async Task SuccessfullyPostKvkRequest()
            {
                //var response = await kvkHelper.SubmitKvkPostRequest(25199268, "69599084");
                //response.Status.Should().Be(200);
                //var PostRequestResponseJsonElement = await requestHelper.ConvertResponseBodyToJsonElement(response);
                //PostRequestResponseJsonElement.GetProperty("Success").ToString().Should().Be("True");
                //PostRequestResponseJsonElement.GetProperty("AzureRequestId").Should().NotBe(null);
                //PostRequestResponseJsonElement.GetProperty("Errors").ToString().Should().Be("[]");

                //string AzureRequestId = PostRequestResponseJsonElement.GetProperty("AzureRequestId").ToString();

                //// Get request
                //var GetResponse = await kvkHelper.RetrieveKvkGetRequest(AzureRequestId);
                //GetResponse.Status.Should().Be(200);
                //var GetRequestResponseJsonElement = await requestHelper.ConvertResponseBodyToJsonElement(GetResponse);

            }
        }
    }
        
}
