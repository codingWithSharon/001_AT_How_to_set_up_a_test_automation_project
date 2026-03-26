using Microsoft.Playwright;
using NUnit.Framework;
using System.Globalization;

[SetUpFixture]
public class GlobalSetup
{
    public static IPlaywright Playwright;

    [OneTimeSetUp]
    public async Task RunBeforeAllTests()
    {
        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

        // Set culture
        var culture = new CultureInfo("nl-NL");
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
        Thread.CurrentThread.CurrentCulture = culture;
        Thread.CurrentThread.CurrentUICulture = culture;
    }

    [OneTimeTearDown]
    public void RunAfterAllTests()
    {
        Playwright?.Dispose();
    }
}
