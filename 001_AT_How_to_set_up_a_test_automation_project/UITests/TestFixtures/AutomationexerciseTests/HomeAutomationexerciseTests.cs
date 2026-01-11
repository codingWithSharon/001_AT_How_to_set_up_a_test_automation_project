using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using PagesSetup;

namespace _001_AT_How_to_set_up_a_test_automation_project.UITests.TestFixtures.HomeAutomationexerciseTests
{
    [TestFixture, Order(1)]
    [Parallelizable(ParallelScope.None)]
    public class HomeAutomationexerciseTests : Setup
    {
        [Test, Order(1), Retry(2)]
        public async Task NavigatingWithNavBar()
        {
            await homeAutomationexercisePage.GoToAutomationexercisePage();
            await Task.Delay(2000);
            await homeAutomationexercisePage.ClickConsentButton();
            await Task.Delay(200);
            await homeAutomationexercisePage.ClickProductButton();
            await Expect(homeAutomationexercisePage._homeButton).ToBeVisibleAsync();
            await homeAutomationexercisePage.ClickHomeButton();
            await Expect(homeAutomationexercisePage._cartButton).ToBeVisibleAsync();
            await homeAutomationexercisePage.ClickCartButton();
            await Expect(homeAutomationexercisePage._homeButton).ToBeVisibleAsync();
            await homeAutomationexercisePage.ClickHomeButton();
            await Expect(homeAutomationexercisePage._signupLoginButton).ToBeVisibleAsync();
            await homeAutomationexercisePage.ClickSignupLoginButton();
            await Expect(homeAutomationexercisePage._homeButton).ToBeVisibleAsync();
            await homeAutomationexercisePage.ClickHomeButton();
            await Expect(homeAutomationexercisePage._testcasesButton).ToBeVisibleAsync();
            await homeAutomationexercisePage.ClickTestcasesButton();
            await Expect(homeAutomationexercisePage._homeButton).ToBeVisibleAsync();
            await homeAutomationexercisePage.ClickHomeButton();
            await Expect(homeAutomationexercisePage._apiTestingButton).ToBeVisibleAsync();
            await homeAutomationexercisePage.ClickApiTestingButton();
            await Expect(homeAutomationexercisePage._homeButton).ToBeVisibleAsync();
            await homeAutomationexercisePage.ClickHomeButton();
            await Expect(homeAutomationexercisePage._contactUsButton).ToBeVisibleAsync();
            await homeAutomationexercisePage.ClickContactUsButton();
            await Expect(homeAutomationexercisePage._videoTutorialsButton).ToBeVisibleAsync();
            await homeAutomationexercisePage.ClickVideoTutorialsButton();
            await Task.Delay(2000);
            await homeAutomationexercisePage.ClickAcceptAllButton();
            await Task.Delay(200);
            await Expect(Page).ToHaveURLAsync(new Regex("https://www.youtube.com/c/AutomationExercise"));

            Console.WriteLine("""
                        Verifying that the Automationexercise home page loads correctly and navigating through various sections of the website by clicking on key navigation buttons:
                        - Home
                        - Products
                        - Cart
                        - Signup / Login
                        - Test Cases
                        - API Testing
                        - Video Tutorials
                        - Contact us
                        """);
        }

    }
}
