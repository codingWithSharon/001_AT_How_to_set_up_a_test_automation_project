using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PagesSetup;
using _001_AT_How_to_set_up_a_test_automation_project.UITests.PageObjectModels;


namespace _001_AT_How_to_set_up_a_test_automation_project.UITests.TestFixtures.SauceDemoTests
{
    [TestFixture, Order(1)]
    [Parallelizable(ParallelScope.None)]
    public class LoginTests : Setup
    {
        [Test, Order(1), Retry(2)]
        public async Task Login_StandardUser()
        {
            await loginSauceDemoPage.GoToLoginSauceDemoPage();
            await loginSauceDemoPage.EnterUsername("standard_user");
            await loginSauceDemoPage.EnterPassword("secret_sauce");
            await loginSauceDemoPage.ClickLoginButton();
            await Expect(loginSauceDemoPage._headerWebshop).ToBeVisibleAsync();
            Console.WriteLine("""   
                    Successful login with standard_user verified by checking the visibility of the webshop header.
                    """);
        }

        [Test, Order(2), Retry(2)]
        public async Task Login_locked_out_user()
        {
            await loginSauceDemoPage.GoToLoginSauceDemoPage();
            await loginSauceDemoPage.EnterUsername("locked_out_user");
            await loginSauceDemoPage.EnterPassword("secret_sauce");
            await loginSauceDemoPage.ClickLoginButton();
            await Expect(loginSauceDemoPage._errorMessage).ToContainTextAsync("Epic sadface: Sorry, this user has been locked out.");
            Console.WriteLine("""   
                    Successful verification of locked out user by checking the error message displayed upon login attempt.
                    """);
        }

        [Test, Order(3), Retry(2)]
        public async Task Login_problem_user()
        {
            await loginSauceDemoPage.GoToLoginSauceDemoPage();
            await loginSauceDemoPage.EnterUsername("problem_user");
            await loginSauceDemoPage.EnterPassword("secret_sauce");
            await loginSauceDemoPage.ClickLoginButton();
            await Expect(loginSauceDemoPage._headerWebshop).ToBeVisibleAsync();
            Console.WriteLine("""   
                    Successful login with problem_user verified by checking the visibility of the webshop header.
                    """);
        }
    }
}
