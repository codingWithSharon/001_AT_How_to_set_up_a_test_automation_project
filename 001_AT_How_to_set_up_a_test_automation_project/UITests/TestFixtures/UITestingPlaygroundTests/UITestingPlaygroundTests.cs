using NUnit.Framework;
using System;
using UITestingPlaygroundPage;

namespace _001_AT_How_to_set_up_a_test_automation_project.UITests.Testfixtures;

[TestFixture]
[Parallelizable(ParallelScope.Children)]
public class UITestingPlaygroundTests : Setup
{
    [Test, Retry(2)]
    public async Task NavigatingTheWebSite()
    {
        await uITestingPlaygroundPage.GoToUITestingPlayground();
        await Expect(uITestingPlaygroundPage._homePageTitle).ToBeVisibleAsync();
        await Expect(uITestingPlaygroundPage._homePageOverview).ToBeVisibleAsync();
        await uITestingPlaygroundPage.SelectAnAutomationPitfall(1, 1);
        await Expect(uITestingPlaygroundPage._dynamicPageDynamicButton).ToContainTextAsync("Dynamic ID");
        await Expect(uITestingPlaygroundPage._homePageOverview).Not.ToBeVisibleAsync();
        await uITestingPlaygroundPage.ClickHomeButton();
        await Expect(uITestingPlaygroundPage._dynamicPageDynamicButton).Not.ToBeVisibleAsync();
        await Expect(uITestingPlaygroundPage._homePageOverview).ToBeVisibleAsync();
        await uITestingPlaygroundPage.ItemChecker();
        Console.WriteLine("""   
                    Quick navigation of the website to check that basic functionality is working. Checks include:

                    - Navigating via the navigation bar
                    - Checking if the correct elements are present on the overview page
                    - Navigating to an item page and checking if the correct elements are present
                    """);
    }
}