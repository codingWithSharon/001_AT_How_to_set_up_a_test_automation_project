//using Microsoft.Playwright;
//using NUnit.Framework;
//using System;
//using UITestingPlaygroundPage;

using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;           // This brings in Expect()
using NUnit.Framework;
using PagesSetup;                           // For your Setup base class
using _001_AT_How_to_set_up_a_test_automation_project.UITests.PageObjectModels;


namespace _001_AT_How_to_set_up_a_test_automation_project.UITests.Testfixtures;

[TestFixture, Order(2)]
//[Parallelizable(ParallelScope.Children)]
//[Parallelizable(ParallelScope.None)]
[Parallelizable(ParallelScope.Fixtures)]
public class UITestingPlaygroundTests : Setup
{
    [Test, Order(1), Retry(2)]
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

    [Test, Order(2), Retry(2)]
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

    [Test, Order(3), Retry(2)]
    public async Task LoadDelayItemTest()
    {
        await uITestingPlaygroundPage.GoToUITestingPlayground();
        await uITestingPlaygroundPage.SelectAnAutomationPitfall(2, 4);
        await Task.Delay(1000);
        await Expect(uITestingPlaygroundPage._loadDelayPageButton).ToBeVisibleAsync();
        await uITestingPlaygroundPage.ClickLoadDelayButton();
        Console.WriteLine("""   
                    Testing the Load Delay item by clicking the button that appears after a delay.
                    Playwright's default timeout will handle waiting for the button to appear.
                    """);
    }

    [Test, Order(4), Retry(2)]
    public async Task AjaxData()
    {
        await uITestingPlaygroundPage.GoToUITestingPlayground();
        await uITestingPlaygroundPage.SelectAnAutomationPitfall(2, 1);
        await uITestingPlaygroundPage.ClickAjaxButton();
        await Task.Delay(1500);
        await Expect(uITestingPlaygroundPage._dataLoaded).ToBeVisibleAsync();
        Console.WriteLine("""   
                    Testing the Ajax Data item by clicking the button and waiting for the data to load.
                    By added delay we ensure the data has time to load before we check for its visibility.
                    """);
    }

    [Test, Order(5), Retry(2)]
    public async Task Click()
    {
        await uITestingPlaygroundPage.GoToUITestingPlayground();
        await uITestingPlaygroundPage.SelectAnAutomationPitfall(2, 3);
        await uITestingPlaygroundPage.ClickBadButton();
        Console.WriteLine("""   
                    Testing the Bad Button item by clicking the button that is known to be problematic.
                    This test ensures that our automation can handle such cases gracefully.
                    """);
    }

    [Test, Order(6), Retry(2)]
    public async Task TextInput()
    {
        await uITestingPlaygroundPage.GoToUITestingPlayground();
        await uITestingPlaygroundPage.SelectAnAutomationPitfall(2, 4);
        await uITestingPlaygroundPage.FillTextInput("New Button Name");
        await uITestingPlaygroundPage.ClickUpdatedTextButton();
        await Expect(uITestingPlaygroundPage._updatedTextButton).ToHaveTextAsync("New Button Name");

        Console.WriteLine("""   
                    Testing the Text Input item by filling in text and verifying the input value.
                    This test ensures that text input fields can be interacted with correctly.
                    """);
    }

    [Test, Order(7), Retry(2)]
    public async Task ScrollBars()
    {
        await uITestingPlaygroundPage.GoToUITestingPlayground();
        await uITestingPlaygroundPage.SelectAnAutomationPitfall(3, 1);
        await uITestingPlaygroundPage.ClickHiddenButton();
        Console.WriteLine("""   
                    Testing the Scroll Bars item by clicking a button that is initially hidden.
                    This test ensures that our automation can scroll to and interact with hidden elements.
                    """);
    }

    [Test, Order(8), Retry(2)]
    public async Task ProgressBar()
    {
        await uITestingPlaygroundPage.GoToUITestingPlayground();
        await uITestingPlaygroundPage.SelectAnAutomationPitfall(3, 4);
        await uITestingPlaygroundPage.ClickStartButton();
        await uITestingPlaygroundPage.WaitForProgressBarToReach(75);
        await uITestingPlaygroundPage.ClickStopButton();
        await Expect(uITestingPlaygroundPage._progressBar).ToHaveAttributeAsync("aria-valuenow", "75");
        Console.WriteLine("""   
                    Testing the Progress Bar item by starting the progress and stopping it at 75%.
                    This test ensures that our automation can interact with dynamic progress elements.
                    """);
    }

    [Test, Order(9), Retry(2)]
    public async Task MouseOver()
    {
        await uITestingPlaygroundPage.GoToUITestingPlayground();
        await uITestingPlaygroundPage.SelectAnAutomationPitfall(4, 3);
        await uITestingPlaygroundPage.ClickClickMeButton();
        await uITestingPlaygroundPage.ClickClickMeButton();
        await Expect(uITestingPlaygroundPage._clickCountClickMeButton).ToHaveTextAsync("2");
        Console.WriteLine("""   
                    Recording the amount of clicks.
                    """);
    }

    [Test, Order(10), Retry(2)]
    public async Task LoginSampleApp()
    {
        await uITestingPlaygroundPage.GoToUITestingPlayground();
        await uITestingPlaygroundPage.SelectAnAutomationPitfall(4, 2);
        await uITestingPlaygroundPage.FillInUserName("testuser");
        await uITestingPlaygroundPage.FillInPassword("testpassword");
        await uITestingPlaygroundPage.ClickLoginButton();
        await Expect(uITestingPlaygroundPage._textLoginStatus).ToHaveTextAsync("Invalid username/password");
        await uITestingPlaygroundPage.FillInUserName("admin");
        await uITestingPlaygroundPage.FillInPassword("pwd");
        await uITestingPlaygroundPage.ClickLoginButton();
        await Expect(uITestingPlaygroundPage._textLoginStatus).ToHaveTextAsync("Welcome, admin!");
        Console.WriteLine("""   
                    Testing the Sample App login functionality with invalid credentials.
                    This test ensures that the login process handles incorrect inputs appropriately.
                    In the second part, we test with valid credentials to ensure successful login.
                    """);
    }

}