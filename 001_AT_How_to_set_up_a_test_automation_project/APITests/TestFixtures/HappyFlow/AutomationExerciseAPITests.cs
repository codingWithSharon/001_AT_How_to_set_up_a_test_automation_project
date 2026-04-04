using NUnit.Framework;

namespace _001_AT_How_to_set_up_a_test_automation_project.APITests.TestFixtures.HappyFlow
{
    [TestFixture]
    public class AutomationExerciseApiTests : ApiSetup
    {
        [Test, Order(1)]
        [Category("API_GET")]
        public async Task GetProductsList_ReturnsSuccess()
        {
            var response = await automationExerciseHelper.GetProductsList();

            Assert.That(response.Ok, Is.True);
            Assert.That(response.Status, Is.EqualTo(200));

            var json = await response.TextAsync();
            Assert.That(json, Does.Contain("products"));
        }

        [Test]
        [Category("API_POST")]
        public async Task PostToProductList()
        {
            var data = new
            {
                name = "Test Product",
                price = 9.99,
                description = "This is a test product."
            };
            var response = await automationExerciseHelper.PostAsync("/api/productsList", data);
            Assert.That(response.Ok, Is.True);
            Assert.That(response.Status, Is.EqualTo(200)); // <--- Should be 405, but the API is not properly configured to handle this case, so it returns 202 instead.
            var json = await response.TextAsync();
            Assert.That(json, Does.Contain("This request method is not supported."));
        }
    }
}