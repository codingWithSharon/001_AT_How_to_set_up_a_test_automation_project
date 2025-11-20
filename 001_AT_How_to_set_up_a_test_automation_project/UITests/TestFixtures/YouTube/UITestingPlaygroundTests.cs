using NUnit.Framework;
using System;
using UITestingPlaygroundPage;

namespace _001_AT_How_to_set_up_a_test_automation_project.UITests.Testfixtures;

[TestFixture]
[Parallelizable(ParallelScope.Children)]
public class UITestingPlaygroundTests : Setup
{
    [Test, Retry(2)]
    public async Task NavigatingTheHomePAge()
    {
        await uITestingPlaygroundPage.GoToUITestingPlayground();
        await Expect(uITestingPlaygroundPage._homePageTitle).ToBeVisibleAsync();
        await Expect(uITestingPlaygroundPage._homePageOverview).ToBeVisibleAsync();
        await uITestingPlaygroundPage.SelectAnAutomationPitfall(1, 1);
    }
}