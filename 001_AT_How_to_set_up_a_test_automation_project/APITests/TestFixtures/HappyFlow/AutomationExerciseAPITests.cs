using NUnit.Framework;

namespace _001_AT_How_to_set_up_a_test_automation_project.APITests.TestFixtures.HappyFlow
{
    [TestFixture]
    public class AutomationExerciseApiTests : ApiSetup
    {
        [Test]
        [Category("API")]
        public async Task GetProductsList_ReturnsSuccess()
        {
            var response = await automationExerciseHelper.GetProductsList();

            Assert.That(response.Ok, Is.True);
            Assert.That(response.Status, Is.EqualTo(200));

            var json = await response.TextAsync();
            Assert.That(json, Does.Contain("products"));
        }
    }
}