using Microsoft.Playwright;

namespace _001_AT_How_to_set_up_a_test_automation_project.UITests.PageObjectModels;

public class UITestingPlaygroundPage : BasePage
{
    #region general
    public UITestingPlaygroundPage(IPage page) : base(page) { }
    public ILocator _homePageTitle => Page.Locator("#title");
    public ILocator _navBarExpandButton => Page.Locator("xpath=//button[@class='navbar-toggler collapsed']");
    public ILocator _navBarCollapseButton => Page.Locator("xpath=//button[@class='navbar-toggler']");
    public ILocator _homePageOverview => Page.Locator("#overview");
    public ILocator SelectAutomationPitfalls(int row, int column) { return Page.Locator($"xpath=/html/body/section[2]/div/div[{row}]/div[{column}]/h3/a"); }

    #endregion



    #region basic operations

    public async Task GoToUITestingPlayground()
    {
        await Page.GotoAsync("http://www.uitestingplayground.com/");
    }

    public async Task ClickExpandNavBar()
    {
        await _navBarExpandButton.ClickAsync();
    }

    public async Task ClickCollapseNavBar()
    {
        await _navBarCollapseButton.ClickAsync();
    }

    public async Task SelectAnAutomationPitfall(int row, int column)
    {
        await SelectAutomationPitfalls(row, column).ClickAsync();
    }

    #endregion
}