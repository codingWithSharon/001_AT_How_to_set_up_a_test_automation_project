using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PagesSetup;
using _001_AT_How_to_set_up_a_test_automation_project.UITests.PageObjectModels;


namespace _001_AT_How_to_set_up_a_test_automation_project.UITests.TestFixtures.VroegPiekenPageTests;

[TestFixture, Order(1)]
[Parallelizable(ParallelScope.None)]
public class VroegPiekenPageTests : Setup
{
    [Test, Order(1)]
    public async Task NavigatingThePage()
    {
        await vroegPiekenPage.GoToVroegPiekenPage();
        await vroegPiekenPage.CheckResultByDate("Rotterdam");

        Console.WriteLine("Launch website and search party by location.");
    }


    [Test, Order(2)]
    public async Task SendRequestSong()
    {
        await vroegPiekenPage.GoToVroegPiekenPage();
        await vroegPiekenPage.SelectAMonth("Maart");
        await vroegPiekenPage.SelectPartyByMonthAndLocation("Maart", "Rotterdam");

        // Option A: direct
        //await vroegPiekenPage.ClickFirstEventOfNextMonth();

        // Option B: if you still want to separate expand + select
        // string nextMonth = vroegPiekenPage.GetNextMonthToggleText();
        // await vroegPiekenPage.ExpandMonth(nextMonth);
        // then find & click first a.event-row yourself

        Console.WriteLine("Navigated to first event of next month → now send your song requests!");
    }
}
