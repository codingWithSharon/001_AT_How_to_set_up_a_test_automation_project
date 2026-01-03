using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace _001_AT_How_to_set_up_a_test_automation_project.UITests.PageObjectModels.YouTubePages
{
    public class HomeYouTubePage : BasePage
    {
        public HomeYouTubePage(IPage page) : base(page) { }

        #region general
        //public ILocator page.GetByRole(AriaRole.Button, new () { Name = "Accept all" }).ClickAsync();
        public ILocator _butonAcceptCookies => Page.Locator("xpath=(//button[@class='yt-spec-button-shape-next yt-spec-button-shape-next--filled yt-spec-button-shape-next--mono yt-spec-button-shape-next--size-m yt-spec-button-shape-next--enable-backdrop-filter-experiment'])[1]");
        public ILocator _overlayBackdrop => Page.Locator("tp-yt-iron-overlay-backdrop.opened");
        public ILocator _youTubeLogo => Page.Locator("ytd-topbar-logo-renderer a#logo").First;
        public ILocator _searchInput => Page.Locator("input[name='search_query']");
        public ILocator _searchButton => Page.Locator("button[aria-label='Search']");
        #endregion

        #region search results
        public ILocator GetVideoByTitleAndUploader(string title, string uploader) =>
            Page.Locator("ytd-video-renderer")
                .Filter(new() { HasText = title })
                .Filter(new() { HasText = uploader })
                .Locator("a#video-title");
        #endregion

        #region video options
        //public ILocator _videoStatus => Page.Locator("video.html5-main-video");
        public ILocator _videoStatus => Page.Locator("#movie_player video.html5-main-video");

        #endregion


        #region basic operations

        #region general operations
        public async Task AcceptCookiesIfPresent()
        {
            if (await _butonAcceptCookies.IsVisibleAsync())
            {
                await _butonAcceptCookies.ClickAsync();
            }
        }
        public async Task GoToYouTubeHomePage()
        {
            await Page.GotoAsync("https://www.youtube.com/");
        }
        public async Task SearchForVideo(string videoName)
        {
            await WaitForOverlayToDisappear();
            await _searchInput.FillAsync(videoName);
            await _searchButton.ClickAsync();
        }
        public async Task WaitForOverlayToDisappear()
        {
            await _overlayBackdrop.WaitForAsync(new()
            {
                State = WaitForSelectorState.Detached,
                Timeout = 15000
            });
        }
        #endregion

        #region search results operations
        public async Task PlayVideoByTitleAndUploader(string title, string uploader)
        {
            var videoLink = GetVideoByTitleAndUploader(title, uploader);
            await videoLink.ClickAsync();
        }
        #endregion

        #region video options operations
        public async Task<bool> IsVideoPlaying()
        {
            return await _videoStatus.EvaluateAsync<bool>("video => " +
                "!video.paused && !video.ended && video.readyState > 2");
        }

        #endregion
        #endregion
    }
}
