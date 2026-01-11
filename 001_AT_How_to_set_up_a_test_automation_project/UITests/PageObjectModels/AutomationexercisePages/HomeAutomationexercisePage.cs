using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using PagesSetup;

namespace _001_AT_How_to_set_up_a_test_automation_project.UITests.PageObjectModels.AutomationexercisePages
{
    public class HomeAutomationexercisePage : BasePage
    {
        public HomeAutomationexercisePage(IPage page) : base(page) { }

        #region general
        public ILocator _consentButton => Page.Locator("button[aria-label=\"Toestemming\"]");
        #endregion

        #region nav bar
        // In the navbar we got 2 unstable elements for the Home and Test cases button there I have choosen to use href locators instead of role locators for those 2.

        public ILocator _homeButton => Page.Locator("a[href='/']").First;
        public ILocator _productButton => Page.GetByRole(AriaRole.Link, new() { Name = " Products" });
        public ILocator _cartButton => Page.GetByRole(AriaRole.Link, new() { Name = " Cart" });
        public ILocator _signupLoginButton => Page.GetByRole(AriaRole.Link, new() { Name = "  Signup / Login" });
        public ILocator _testcasesButton => Page.Locator("a[href='/test_cases']").First;
        public ILocator _apiTestingButton => Page.GetByRole(AriaRole.Link, new() { Name = " API Testing" });
        public ILocator _videoTutorialsButton => Page.GetByRole(AriaRole.Link, new() { Name = " Video Tutorials" });
        public ILocator _contactUsButton => Page.GetByRole(AriaRole.Link, new() { Name = " Contact us" });
        #endregion

        #region confirmation elements
        public ILocator _acceptAllButton => Page.GetByRole(AriaRole.Button, new() { Name = "Alles accepteren" });
        #endregion


        #region basic operations general
        public async Task GoToAutomationexercisePage()
        {
            await Page.GotoAsync("https://automationexercise.com/");
        }
        public async Task ClickConsentButton()
        {
            if (await _consentButton.IsVisibleAsync())
            {
                await _consentButton.ClickAsync(new() { Force = true });
            }
        }
        public async Task ClickHomeButton()
        {
            await _homeButton.ClickAsync(new() { Force = true });
        }
        public async Task ClickProductButton()
        {
            await _productButton.ClickAsync(new() { Force = true });
        }
        public async Task ClickCartButton()
        {
            await _cartButton.ClickAsync(new() { Force = true });
        }
        public async Task ClickSignupLoginButton()
        {
            await _signupLoginButton.ClickAsync(new() { Force = true });
        }
        public async Task ClickTestcasesButton()
        {
            await _testcasesButton.ClickAsync(new() { Force = true });
        }
        public async Task ClickApiTestingButton()
        {
            await _apiTestingButton.ClickAsync(new() { Force = true });
        }
        public async Task ClickVideoTutorialsButton()
        {
            await _videoTutorialsButton.ClickAsync(new() { Force = true });
        }
        public async Task ClickContactUsButton()
        {
            await _contactUsButton.ClickAsync(new() { Force = true });
        }
        //public async Task ClickAcceptAllButton()
        //{
        //    await _acceptAllButton.ClickAsync();
        //}

        public async Task ClickAcceptAllButton()
        {
            try
            {
                if (await _acceptAllButton.IsVisibleAsync(new() { Timeout = 2000 }))
                {
                    await _acceptAllButton.ClickAsync(new() { Force = true });
                }
            }
            catch
            {
                // Banner not present — ignore
            }
        }

        #endregion
    }
}
