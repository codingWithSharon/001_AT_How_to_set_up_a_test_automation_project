using Microsoft.Playwright;

namespace _001_AT_How_to_set_up_a_test_automation_project.UITests.PageObjectModels;

public class UITestingPlaygroundPage : BasePage
{
    
    public UITestingPlaygroundPage(IPage page) : base(page) { }

    #region nav bar
    public ILocator _navBarExpandButton => Page.Locator("xpath=//button[@class='navbar-toggler collapsed']");
    public ILocator _navBarCollapseButton => Page.Locator("xpath=//button[@class='navbar-toggler']");
    public ILocator _navBarHomeButton => Page.Locator("xpath=(//*[@class='nav-link'])[1]");
    public ILocator _navBarResourcesButton => Page.Locator("xpath=(//*[@class='nav-link'])[2]");
    #endregion

    #region overview homepage
    public ILocator _homePageTitle => Page.Locator("#title");
    public ILocator _homePageOverview => Page.Locator("#overview");
    public ILocator SelectAutomationPitfallsLoop(int row, int column) { return Page.Locator($"xpath=/html/body/section[2]/div/div[{row}]/div[{column}]/h3/a"); }
    public ILocator SelectAutomationPitfalls(int row, int column) { return Page.Locator($"xpath=/html/body/section[2]/div/div[{row}]/div[{column}]/h3/a"); }
    #endregion

    #region dynamic page
    public ILocator _dynamicPageDynamicButton => Page.Locator("xpath=//*[@class='btn btn-primary']");
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

    public async Task ClickHomeButton()
    {
        await _navBarHomeButton.ClickAsync();
    }

    public async Task ClickResourcesButton()
    {
        await _navBarResourcesButton.ClickAsync();
    }

    public async Task SelectAnAutomationPitfall(int row, int column)
    {
        await SelectAutomationPitfalls(row, column).ClickAsync();
    }
    #endregion

    #region complex operations
    public async Task ItemChecker()
    {
        Console.WriteLine("=== All Automation Pitfalls ===");

        for (int row = 1; row <= 4; row++)
        {
            for (int column = 1; column <= 4; column++)
            {
                var title = SelectAutomationPitfallsLoop(row, column);
                Console.WriteLine($"Row {row}, Col {column}: {await SelectAutomationPitfallsLoop(row, column).InnerTextAsync()}");
                var link = SelectAutomationPitfallsLoop(row, column);
                await Expect(link).ToBeVisibleAsync();
                string itemTitle = await link.InnerTextAsync();
                Console.WriteLine($"Row {row}, Col {column}: {title} [VISIBLE]");
            }
        }

        Console.WriteLine("=== Total 9 items listed successfully ===\n");
    }
    #endregion
}