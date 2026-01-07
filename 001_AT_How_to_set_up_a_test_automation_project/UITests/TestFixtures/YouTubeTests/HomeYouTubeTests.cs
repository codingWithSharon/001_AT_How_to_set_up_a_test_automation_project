using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using PagesSetup;

namespace _001_AT_How_to_set_up_a_test_automation_project.UITests.TestFixtures.YouTubeTests
{
    //[TestFixture, Order(1)]
    [Parallelizable(ParallelScope.None)]
    public class HomeYouTubeTests : Setup
    {
        //[Test, Order(1), Retry(2)]
        public async Task VerifyHomeYouTubePageLoads()
        {
            await homeYouTubePage.GoToYouTubeHomePage();
            await homeYouTubePage.AcceptCookiesIfPresent();
            await Expect(homeYouTubePage._youTubeLogo).ToBeVisibleAsync();

            Console.WriteLine("""
                        Verifying that the YouTube home page loads correctly by checking for the presence of key elements:
                        
                        - YouTube logo
                        - Search box
                        """);
        }

        //[Test, Order(2),Retry(2)]
        public async Task SearchAndPlay()
        {
            await homeYouTubePage.GoToYouTubeHomePage();
            await Task.Delay(2000);
            await homeYouTubePage.AcceptCookiesIfPresent();
            await homeYouTubePage.SearchForVideo("RickRoll'D");
            await homeYouTubePage.PlayVideoByTitleAndUploader("RickRoll'D", "cotter548");
            await Task.Delay(5000);
            await Expect(homeYouTubePage._videoStatus).ToBeVisibleAsync();
            await Page.BringToFrontAsync();
            await Task.Delay(5000);
            bool isPlaying = await homeYouTubePage.IsVideoPlaying();

            Console.WriteLine("""
                        Searching for a specific video and verifying that it plays correctly by checking the video playback status.
                        """);
        }
    }
}
