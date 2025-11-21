using Microsoft.Playwright;
using NUnit.Framework;
using System;
using UITestingPlaygroundPage;


namespace _001_AT_How_to_set_up_a_test_automation_project.UITests.Testfixtures;

[TestFixture]
//[Parallelizable(ParallelScope.Children)]
[Parallelizable(ParallelScope.None)]
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

    [Test, Retry(2)]
    public async Task ClassAttributeItemTest()
    {
        await uITestingPlaygroundPage.DialogPopupHandler();
        await uITestingPlaygroundPage.GoToUITestingPlayground();
        await uITestingPlaygroundPage.SelectAnAutomationPitfall(1, 2);
        await uITestingPlaygroundPage.ClickBlueButton();
        Console.WriteLine("""   
                    Making sure we click the blue button by using a robust selector and dealing with the alert dialog.
                    Note that Playwright automatically handles alert dialogs, so we don't have to do anything special here.
                    However, we do log the dialog message to the console for verification.
                    """);
    }


}