//using NUnit.Framework;
//using Microsoft.Playwright;
//using Microsoft.Playwright.NUnit;
//using _001_AT_How_to_set_up_a_test_automation_project.APITests.Helpers.SpecificHelper;

//namespace _001_AT_How_to_set_up_a_test_automation_project.APITests;

//public class ApiSetup : ContextTest
//{
//    public IPage Page { get; private set; } = null!;
//    public IAPIRequestContext IAPIRequestContext { get; private set; } = null!;

//    public VroegPiekenHelper vroegPiekenHelper = null!;
//    public AutomationExerciseHelper automationExerciseHelper = null!;


//    [OneTimeSetUp]
//    public async Task PageSetupAPi()
//    {
//        var playwright = GlobalSetup.Playwright;
//        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
//        {
//            Headless = true
//        });
//        var Context = await browser.NewContextAsync();
//        Page = await Context.NewPageAsync().ConfigureAwait(true);
//        Page.SetDefaultTimeout(6000);
//        IAPIRequestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
//        {
//            Timeout = 300000
//        });

//        vroegPiekenHelper = new VroegPiekenHelper(IAPIRequestContext);
//        automationExerciseHelper = new AutomationExerciseHelper(IAPIRequestContext);
//    }

//    [OneTimeTearDown]
//    public async Task TearDown()
//    {
//        await Page.CloseAsync();
//    }

//}

using NUnit.Framework;
using Microsoft.Playwright;
using _001_AT_How_to_set_up_a_test_automation_project.APITests.Helpers.SpecificHelper;
using _001_AT_How_to_set_up_a_test_automation_project.APITests.Helpers.GenericHelper;

namespace _001_AT_How_to_set_up_a_test_automation_project.APITests;

public class ApiSetup
{
    protected IAPIRequestContext Api { get; private set; } = null!;

    protected RequestHelper requestHelper = null!;

    protected VroegPiekenHelper vroegPiekenHelper = null!;
    protected AutomationExerciseHelper automationExerciseHelper = null!;

    [OneTimeSetUp]
    public async Task Setup()
    {
        var playwright = await Playwright.CreateAsync();

        Api = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
        {
            Timeout = 300000
        });

        // Generic API Helper initialization
        //RequestHelper requestHelper = new RequestHelper(Api);

        // API Specific helpers initialization
        vroegPiekenHelper = new VroegPiekenHelper(Api);
        automationExerciseHelper = new AutomationExerciseHelper(Api);
    }

    [OneTimeTearDown]
    public async Task Teardown()
    {
        await Api.DisposeAsync();
    }
}
