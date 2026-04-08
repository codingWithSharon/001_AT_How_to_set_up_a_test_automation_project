using _001_AT_How_to_set_up_a_test_automation_project.APITests.Models.Responses;
using FluentAssertions;
using NUnit.Framework;

namespace _001_AT_How_to_set_up_a_test_automation_project.APITests.TestFixtures.HappyFlow
{
    [TestFixture]
    public class AutomationExerciseApiTests : ApiSetup
    {

        // json requests //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [Test, Order(1)]
        [Category("API_GET")]
        public async Task GET_ProductsList()
        {
            var response = await automationExerciseHelper.GetRequest("/api/productsList");

            Assert.That(response.Ok, Is.True);
            Assert.That(response.Status, Is.EqualTo(200));

            var json = await response.TextAsync();
            Assert.That(json, Does.Contain("products"));

            TestContext.WriteLine("Response body:");
            TestContext.WriteLine(json);
        }

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

            var response = await automationExerciseHelper.PostAsyncJson("/api/productsList", data);

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
            var response = await automationExerciseHelper.GetRequest("/api/brandsList", null, null);
            Assert.That(response.Ok, Is.True);
            Assert.That(response.Status, Is.EqualTo(200));
            var json = await response.TextAsync();
            Assert.That(json, Does.Contain("brands"));

            TestContext.WriteLine("Response body:");
            TestContext.WriteLine(json);
        }

        [Test]
        [Category("API_PUT")]
        public async Task PUT_ToAllBrandsListValidation()
        {
            var response = await automationExerciseHelper.PutRequest("/api/brandsList", null, null);
            Assert.That(response.Status, Is.EqualTo(200));
            var json = await response.TextAsync();

            TestContext.WriteLine("Response body:");
            TestContext.WriteLine(json);

            var errorResponse = System.Text.Json.JsonSerializer.Deserialize
            <GenericResponseModels.ApiErrorResponse>(json);

            errorResponse.Should().NotBeNull("Failed to deserialize the error response");
            errorResponse.responseCode.Should().Be(405);
            errorResponse.message.Should().Contain("This request method is not supported.");

            json.Should().Contain("This request method is not supported.");
        }

        // x-www-form-urlencoded requests //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Test]
        [Category("API_POST")]
        public async Task POST_ToSearchProduct()
        {
            var formData = new Dictionary<string, string>
            {
                { "search_product", "blue top" } // <--Request consists of 1 key-value pair, where the key is "search_product" and the value is "blue top"
            };

            var response = await automationExerciseHelper
                .PostAsyncFormUrlEncoded("/api/searchProduct", formData);

            Assert.That(response.Status, Is.EqualTo(200));

            var json = await response.TextAsync();

            TestContext.WriteLine("Response body:");
            TestContext.WriteLine(json);

            var result = System.Text.Json.JsonSerializer.Deserialize<SearchProductResponse>(
                json,
                new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            result.Should().NotBeNull();
            result.responseCode.Should().Be(200);
            result.products.Should().NotBeNullOrEmpty();
            result.products.Any(p => p.name.Contains("blue", StringComparison.OrdinalIgnoreCase)).Should().BeTrue("Expected at least one product with 'Blue' in the name");
        }
    }
}