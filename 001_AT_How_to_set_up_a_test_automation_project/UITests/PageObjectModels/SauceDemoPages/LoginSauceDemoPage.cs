using Microsoft.Playwright;
using NUnit.Framework;

namespace _001_AT_How_to_set_up_a_test_automation_project.UITests.PageObjectModels.SauceDemoPages;

public class LoginSauceDemoPage : BasePage
{
    public LoginSauceDemoPage(IPage page) : base(page) { }

    #region general
    public ILocator _inputUsername => Page.Locator("#user-name");
    public ILocator _inputPassword => Page.Locator("#password");
    public ILocator _loginButton => Page.Locator("#login-button");
    public ILocator _headerWebshop => Page.Locator("//*[@class='header_secondary_container']");
    public ILocator _errorMessage => Page.Locator("//*[@class='error-message-container error']");
    #endregion

    #region basic operations login page
    public async Task GoToLoginSauceDemoPage()
    {
        await Page.GotoAsync("https://www.saucedemo.com/");
    }

    public async Task EnterUsername(string username)
    {
        await _inputUsername.FillAsync(username);
    }

    public async Task EnterPassword(string password)
    {
        await _inputPassword.FillAsync(password);
    }

    public async Task ClickLoginButton()
    {
        await _loginButton.ClickAsync();
    }
    #endregion
}