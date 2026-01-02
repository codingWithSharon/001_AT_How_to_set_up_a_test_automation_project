using Microsoft.Playwright;
using NUnit.Framework;

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
    //public ILocator SelectAutomationPitfalls(int row, int column) { return Page.Locator($"xpath=/html/body/section[2]/div/div[{row}]/div[{column}]/h3/a"); } // OLD
    public ILocator SelectAutomationPitfalls(int row, int column) { return Page.Locator($"//*[@id=\"overview\"]/div/div[{row}]/div[{column}]/h3/a"); } // NEW
    #endregion

    #region dynamic page
    public ILocator _dynamicPageDynamicButton => Page.Locator("xpath=//*[@class='btn btn-primary']");
    #endregion

    #region class attribute page
    public ILocator _classAttributePageBlueButton => Page.Locator("xpath=(//button[contains(concat(' ', normalize-space(@class), ' '), ' btn-primary ')])[1]");
    #endregion

    #region load delay page
    public ILocator _loadDelayPageButton => Page.Locator("xpath=//button[@class='btn btn-primary']");
    #endregion

    #region ajax data page
    public ILocator _ajaxButton => Page.Locator("#ajaxButton"); 
    public ILocator _dataLoaded => Page.Locator("xpath=//*[@class='bg-success']");
    #endregion

    #region bad button page
    public ILocator _badButton => Page.Locator("#badButton");
    #endregion

    #region text input
    public ILocator _textInputBox => Page.Locator("#newButtonName");
    public ILocator _updatedTextButton => Page.Locator("#updatingButton");
    #endregion

    #region scroll bars
    public ILocator _hiddenButton => Page.Locator("#hidingButton");
    #endregion

    #region progress bar
    public ILocator _startButton => Page.Locator("#startButton");
    public ILocator _stopButton => Page.Locator("#stopButton");
    public ILocator _progressBar => Page.Locator("#progressBar");
    #endregion

    #region mouse over page
    //public ILocator _clickMeButton => Page.Locator("(//*[@class='text-primary'])[1]");
    public ILocator _clickMeButton => Page.Locator("xpath=/html/body/section/div/div[1]/a");
    public ILocator _linkButton => Page.Locator("(//*[@class='text-primary'])[2]");
    public ILocator _clickCountClickMeButton => Page.Locator("#clickCount");
    public ILocator _clickCountLinkButton => Page.Locator("#clickButtonCount");
    #endregion

    #region sample app
    public ILocator _inputUserName => Page.Locator("xpath=(//*[@class='form-control'])[1]");
    public ILocator _inputPassword => Page.Locator("xpath=(//*[@class='form-control'])[2]");
    public ILocator _buttonLogin => Page.Locator("#login");
    public ILocator _textLoginStatus => Page.Locator("#loginstatus");
    #endregion

    #region basic operations overview page
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

    #region basic operations class attribute page
    public async Task ClickBlueButton()
    {
        await _classAttributePageBlueButton.ClickAsync();
    }
    #endregion

    #region basic opaerations load delay page
    public async Task ClickLoadDelayButton()
    {
        await _loadDelayPageButton.ClickAsync();
    }
    #endregion

    #region basic operations ajax data page
    public async Task ClickAjaxButton()
    {
        await _ajaxButton.ClickAsync();
    }
    #endregion

    #region basic operations bad button page
    public async Task ClickBadButton()
    {
        await _badButton.ClickAsync();
    }
    #endregion

    #region basic operations text input page
    public async Task FillTextInput(string inputText)
    {
        await _textInputBox.FillAsync(inputText);
    }

    public async Task ClickUpdatedTextButton()
    {
        await _updatedTextButton.ClickAsync();
    }
    #endregion

    #region basic operations scroll bars page
    public async Task ClickHiddenButton()
    {
        await _hiddenButton.ClickAsync();
    }
    #endregion

    #region basic operations progress bar page
    public async Task ClickStartButton()
    {
        await _startButton.ClickAsync();
    }

    public async Task ClickStopButton()
    {
        await _stopButton.ClickAsync();
    }

    public async Task<double> GetProgressBarValue()
    {
        string progressValue = await _progressBar.GetAttributeAsync("aria-valuenow") ?? "0";
        return double.Parse(progressValue);
        Console.WriteLine($"Current Progress Bar Value: {progressValue}");
    }

    public async Task GetProgressBarValuAndCompare()
    {
        string valueText = await Page.GetAttributeAsync(".progress-bar", "aria-valuenow");
        int currentValue = int.Parse(valueText);
        if (currentValue == 75)
        {
            Console.WriteLine("Progress bar has reached 75%.");
        }
        else
        {
            Console.WriteLine($"Progress bar is at {currentValue}%, not 75%.");
        }
    }

    public async Task WaitForProgressBarToReach(double targetValue)
    {
        while (true)
        {
            double currentValue = await GetProgressBarValue();
            if (currentValue == targetValue)
            {
                break;
            }
            //await Task.Delay(50);
        }
    }
    #endregion

    #region basic operations mouse over page
    public async Task ClickClickMeButton()
    {
        await _clickMeButton.ClickAsync();
    }
    public async Task HoverLinkButton()
    {
        await _linkButton.ClickAsync();
    }
    #endregion

    #region basic operations sample app
    public async Task FillInUserName(string userName)
    {
        await _inputUserName.FillAsync(userName);
    }

    public async Task FillInPassword(string password)
    {
        await _inputPassword.FillAsync(password);
    }

    public async Task ClickLoginButton()
    {
        await _buttonLogin.ClickAsync();
    }
    #endregion

    // ========= COMPLEX OPERATIONS ========= //

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

    public async Task DialogPopupHandler()
    {
        Page.Dialog += async (_, dialog) =>
        {
            Console.WriteLine($"Dialog detected → Type: {dialog.Type}, Message: '{dialog.Message}'");
            await dialog.DismissAsync();
        };

        await Page.EvaluateAsync("() => alert('This alert was handled by Playwright!')");
        var title = await Page.TitleAsync();
        Assert.That(title, Is.Not.Null.Or.Empty);
    }
    #endregion
}