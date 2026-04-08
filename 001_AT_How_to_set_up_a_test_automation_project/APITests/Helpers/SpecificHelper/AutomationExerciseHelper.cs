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

        // JSON
        public async Task<IAPIResponse> PostAsyncJson(string endpoint, object? data = null, Dictionary<string, string>? headers = null)
        {
            var requestOptions = new APIRequestContextOptions
            {
                DataObject = data,
                Headers = headers
            };

            return await _context.PostAsync($"{AutomationExerciseBaseUrl}{endpoint}", requestOptions);
        }

        // ==============================================================================================================

        // Form-urlencoded - Simple & Reliable version
        //public async Task<IAPIResponse> PostAsyncFormUrlEncoded(string endpoint, Dictionary<string, string> formData, Dictionary<string, string>? headers = null)
        //{
        //    var requestOptions = new APIRequestContextOptions
        //    {
        //        Form = formData,
        //        Headers = headers
        //    };
        //    return await _context.PostAsync($"{AutomationExerciseBaseUrl}{endpoint}", requestOptions);
        //}


        public async Task<IAPIResponse> PostAsyncFormUrlEncoded(
            string endpoint,
            Dictionary<string, string> formData,
            Dictionary<string, string>? headers = null)
        {
            var form = _context.CreateFormData();

            foreach (var kvp in formData)
            {
                form.Append(kvp.Key, kvp.Value);
            }

            var requestOptions = new APIRequestContextOptions
            {
                Form = form,
                Headers = headers
            };

            return await _context.PostAsync(
                $"{AutomationExerciseBaseUrl}{endpoint}",
                requestOptions
            );
        }



        // ==============================================================================================================

        public async Task<IAPIResponse> GetRequest(string endpoint, object? data = null, Dictionary<string, string>? headers = null)
        {
            var requestOptions = new APIRequestContextOptions
            {
                DataObject = data,
                Headers = headers
            };

            return await _context.GetAsync($"{AutomationExerciseBaseUrl}{endpoint}", requestOptions);
        }

        public async Task<IAPIResponse> PutRequest(string endpoint, object? data = null, Dictionary<string, string>? headers = null)
        {
            var requestOptions = new APIRequestContextOptions
            {
                DataObject = data,
                Headers = headers
            };
            return await _context.PutAsync($"{AutomationExerciseBaseUrl}{endpoint}", requestOptions);
        }
    }   
}