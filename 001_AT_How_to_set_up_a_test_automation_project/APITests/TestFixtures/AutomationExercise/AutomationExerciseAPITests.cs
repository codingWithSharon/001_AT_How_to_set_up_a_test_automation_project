using _001_AT_How_to_set_up_a_test_automation_project.APITests.Models.Responses;
using NUnit.Framework;
using FluentAssertions;

namespace _001_AT_How_to_set_up_a_test_automation_project.APITests.TestFixtures.HappyFlow
{
    [TestFixture]
    public class AutomationExerciseApiTests : ApiSetup
    {
        [Test, Order(1)]
        [Category("API_GET")]
        public async Task GET_ProductsList()
        {
            var response = await automationExerciseHelper.GetProductsList("/api/productsList");

            Assert.That(response.Ok, Is.True);
            Assert.That(response.Status, Is.EqualTo(200));

            var json = await response.TextAsync();
            Assert.That(json, Does.Contain("products"));

            // Write response body to test log
            TestContext.WriteLine("Response body:");
            TestContext.WriteLine(json);
        }

        //[Test]
        //[Category("API_POST")]
        //public async Task POST_ToProductListValidation()
        //{
        //    var data = new
        //    {
        //        name = "Test Product",
        //        price = 9.99,
        //        description = "This is a test product."
        //    };
        //    var response = await automationExerciseHelper.PostAsync("/api/productsList", data);
        //    Assert.That(response.Ok, Is.True);
        //    Assert.That(response.Status, Is.EqualTo(200)); // <--- Should be 405, but the API is not properly configured to handle this case, so it returns 202 instead.
        //    var json = await response.TextAsync();
        //    Assert.That(json, Does.Contain("This request method is not supported."));

        //    var errorResponse = System.Text.Json.JsonSerializer.Deserialize
        //    <AutomationExerciseResponseModels.ApiErrorResponse>(json);

        //    AutomationExerciseResponseModels.ApiErrorResponse.responseCode.Should().Be(405);

        //    // Write response body to test log
        //    TestContext.WriteLine("Response body:");
        //    TestContext.WriteLine(json);
        //}

        [Test]
        [Category("API_POST")]
        public async Task POST_ToProductListValidation()
        {
            var data = new
            {
                name = "Test Product",
                price = 9.99,
                description = "This is a test product."
            };

            var response = await automationExerciseHelper.PostAsync("/api/productsList", data);

            // According to AutomationExercise API spec, this endpoint should return 405 when using POST
            response.Status.Should().Be(200);           // This is the main check
                                                        // response.Ok.Should().BeFalse();          // Optional - Ok is true only for 2xx

            var json = await response.TextAsync();

            // Log the response so you can see exactly what comes back
            TestContext.WriteLine("Response body:");
            TestContext.WriteLine(json);

            // Deserialize into your model
            var errorResponse = System.Text.Json.JsonSerializer.Deserialize
                <GenericResponseModels.ApiErrorResponse>(json);

            // Now use the INSTANCE, not the class name
            errorResponse.Should().NotBeNull("Failed to deserialize the error response");
            errorResponse.responseCode.Should().Be(405);
            errorResponse.message.Should().Contain("This request method is not supported.");

            // Optional: also check the raw JSON contains the message (as a fallback)
            json.Should().Contain("This request method is not supported.");
        }

        [Test]
        [Category("API_GET")]
        public async Task GET_AllBrandsList()
        {
            var response = await automationExerciseHelper.GetAllBrandsList("/api/brandsList", null, null);
            Assert.That(response.Ok, Is.True);
            Assert.That(response.Status, Is.EqualTo(200));
            var json = await response.TextAsync();
            Assert.That(json, Does.Contain("brands"));

            // Write response body to test log
            TestContext.WriteLine("Response body:");
            TestContext.WriteLine(json);
        }
    }
}