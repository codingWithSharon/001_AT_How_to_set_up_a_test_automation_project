using System.Text.Json;

namespace _001_AT_How_to_set_up_a_test_automation_project.APITests.Models.Responses
{
    public class SearchProductResponse
    {
        public int responseCode { get; set; }
        public List<Product> products { get; set; }
    }

    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public string brand { get; set; }
        public JsonElement category { get; set; }
    }
}
