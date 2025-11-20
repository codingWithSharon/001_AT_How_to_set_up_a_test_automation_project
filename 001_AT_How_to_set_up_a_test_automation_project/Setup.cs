//using Microsoft.Playwright.NUnit;


using _001_AT_How_to_set_up_a_test_automation_project.UITests.PageObjectModels;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace UITestingPlaygroundPage;

public class Setup : ContextTest
{
    public IAPIRequestContext IAPIRequestContext { get; private set; } = null!;
    public IPage Page { get; private set; } = null!;

    public _001_AT_How_to_set_up_a_test_automation_project.UITests.PageObjectModels.UITestingPlaygroundPage uITestingPlaygroundPage = null!;

    public override BrowserNewContextOptions ContextOptions()
    {
        return new BrowserNewContextOptions
        {
            Locale = "nl-NL",
            TimezoneId = "Europe/Amsterdam",
            ViewportSize = new() { Width = 1920, Height = 1080 },
            UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36",
            BypassCSP = true,
            // Important for YouTube: accept Dutch + allow some permissions
            Permissions = new[] { "geolocation" },
            Geolocation = new() { Latitude = 52.3702f, Longitude = 4.8952f }, // Amsterdam
            // Headless is controlled by .runsettings, not here
        };
    }

    [SetUp]
    public async Task StartTracing()
    {
        //IAPIRequestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
        //{
        //    Timeout = 150000
        //});

        Page = await Context.NewPageAsync();

        uITestingPlaygroundPage = new _001_AT_How_to_set_up_a_test_automation_project.UITests.PageObjectModels.UITestingPlaygroundPage(Page);
        await Context.Tracing.StartAsync(new()
        {
            Screenshots = true,
            Snapshots = true,
            Sources = true,
            Title = $"{TestContext.CurrentContext.Test.FullName}"
        });
    }

    [TearDown]
    public async Task StopTracing()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            var path = Path.Combine(TestContext.CurrentContext.WorkDirectory,
                "traces",
                $"{TestContext.CurrentContext.Test.Name}.zip");
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            await Context.Tracing.StopAsync(new() { Path = path });
        }
    }
}