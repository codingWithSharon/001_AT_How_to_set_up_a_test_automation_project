using Microsoft.Playwright;

namespace _001_AT_How_to_set_up_a_test_automation_project.APITests.Helpers.SpecificHelper
{
    public class AutomationExerciseHelper
    {
        public readonly IAPIRequestContext _context;

        public readonly string AutomationExerciseBaseUrl =
            Environment.GetEnvironmentVariable("AutomationExerciseApiBaseUrl")
            ?? throw new InvalidOperationException("AutomationExerciseApiBaseUrl not set.");

        public AutomationExerciseHelper(IAPIRequestContext context)
        {
            _context = context;
        }

        public async Task<IAPIResponse> GetProductsList(string endpoint)
        {
            return await _context.GetAsync($"{AutomationExerciseBaseUrl}{endpoint}");
        }

        public async Task<IAPIResponse> PostAsync(string endpoint, object? data = null, Dictionary<string, string>? headers = null)
        {
            var requestOptions = new APIRequestContextOptions
            {
                DataObject = data,
                Headers = headers
            };

            return await _context.PostAsync($"{AutomationExerciseBaseUrl}{endpoint}", requestOptions);
        }

        public async Task<IAPIResponse> GetAllBrandsList(string endpoint, object? data = null, Dictionary<string, string>? headers = null)
        {
            var requestOptions = new APIRequestContextOptions
            {
                DataObject = data,
                Headers = headers
            };

            return await _context.GetAsync($"{AutomationExerciseBaseUrl}{endpoint}", requestOptions);
        }
    }   
}