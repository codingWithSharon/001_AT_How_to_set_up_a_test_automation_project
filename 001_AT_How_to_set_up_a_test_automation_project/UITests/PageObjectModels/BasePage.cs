using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace _001_AT_How_to_set_up_a_test_automation_project.UITests.PageObjectModels;

public abstract class BasePage : ContextTest 
{
    public IPage Page { get; private set; } = null!;

    public BasePage(IPage page)
    {
        Page = page;
    }
}


