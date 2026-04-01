using Microsoft.Playwright;

namespace _001_AT_How_to_set_up_a_test_automation_project.APITests.Helpers.SpecificHelper
{
    public class AutomationExerciseHelper
    {
        private readonly IAPIRequestContext _context;

        private readonly string BaseUrl =
            Environment.GetEnvironmentVariable("AutomationExerciseApiBaseUrl")
            ?? throw new InvalidOperationException("AutomationExerciseApiBaseUrl not set.");

        public AutomationExerciseHelper(IAPIRequestContext context)
        {
            _context = context;
        }

        public async Task<IAPIResponse> GetProductsList()
        {
            return await _context.GetAsync($"{BaseUrl}/api/productsList");
        }
    }
}