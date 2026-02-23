using Microsoft.Playwright;
using NUnit.Framework;

namespace _001_AT_How_to_set_up_a_test_automation_project.UITests.PageObjectModels.VroegPiekenPages;

public class VroegPiekenPage : BasePage
{
    public VroegPiekenPage(IPage page) : base(page) { }

    #region general
    public ILocator _searchByLocation => Page.Locator("#eventSearchInput");
    public ILocator AccordionToggle(string monthText) => Page.Locator(".accordion-toggle", new() { HasText = monthText });
    public ILocator GetItemByLocation(string location) => Page.Locator(".event-row", new() { Has = Page.Locator(".location-title", new() { HasText = location }) });
    public ILocator GetEventRowByLocationInMonth(string month, string location) => Page.Locator($"text={month} >> visible=true").Locator("xpath=following::a[contains(@class,'event-row') or contains(@href,'/event/')][contains(., '{location.ToUpperInvariant()}')][1]");

    #endregion

    #region basic operations
    public async Task GoToVroegPiekenPage()
    {
        await Page.GotoAsync("https://vroegpieken.com/");
    }

    public async Task SelectAMonth(string month)
    {
        await AccordionToggle(month).ClickAsync();
    }

    public async Task CheckResultByDate(string location)
    {
        await Expect(GetItemByLocation(location)).ToBeVisibleAsync();
    }

    public async Task SelectPartyByMonthAndLocation(string month, string location)
    {
        await GetEventRowByLocationInMonth(month, location).ClickAsync();
    }
    #endregion

    #region helper
    public string GetDutchMonthName(int monthNumber)
    {
        return monthNumber switch
        {
            1 => "Januari",
            2 => "Februari",
            3 => "Maart",
            4 => "April",
            5 => "Mei",
            6 => "Juni",
            7 => "Juli",
            8 => "Augustus",
            9 => "September",
            10 => "Oktober",
            11 => "November",
            12 => "December",
            _ => throw new ArgumentOutOfRangeException(nameof(monthNumber))
        };
    }

    public string GetNextMonthToggleText()
    {
        var today = DateTime.Today;
        var nextMonth = today.AddMonths(1); // Select how many months ahead you want to select
        string dutchName = GetDutchMonthName(nextMonth.Month);
        return $"{dutchName} {nextMonth.Year}";
    }

    public async Task ExpandMonth(string monthDisplayText)
    {
        var toggle = Page.Locator(".accordion-toggle", new() { HasText = monthDisplayText });

        bool isActive = await toggle.EvaluateAsync<bool>("el => el.classList.contains('active')");
        if (!isActive)
        {
            await toggle.ClickAsync(new LocatorClickOptions { Timeout = 8000 });
            await Page.Locator(".accordion-content[style*='display: block']", new() { Has = toggle })
                      .WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 6000 });
        }
    }


    #endregion

    #region complex operations
    public async Task ClickFirstEventOfNextMonth()
    {
        string nextMonthText = GetNextMonthToggleText();

        // Expand the correct month
        await ExpandMonth(nextMonthText);

        // Now find event rows inside that month's content
        // From your screenshot: <a class="event-row" href="..."> inside .accordion-content
        //var eventRows = Page.Locator($".accordion-toggle:has-text('{nextMonthText}') >> xpath=following-sibling::div[contains(@class,'accordion-content')] >> a.event-row");

        //int count = await eventRows.CountAsync();
        //if (count == 0)
        //{
        //    throw new Exception($"No events found in {nextMonthText} after expanding.");
        //}

        //// Click the first visible one
        //var firstEvent = eventRows.First;
        //await firstEvent.ClickAsync(new LocatorClickOptions { Timeout = 10000 });

        //// Optional: wait for navigation or detail page load
        //await Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
    }
    #endregion
}