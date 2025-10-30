using Microsoft.Playwright;

namespace PlaywrightTests.Pages
{
    public class IframePage
    {
        private readonly IPage _page;
        private readonly IFrameLocator _iframe;

        // Locators outside iframe
        private readonly ILocator _mainHeading;

        // Locators inside iframe
        private readonly ILocator _iframeButton;
        private readonly ILocator _iframeInput;
        private readonly ILocator _iframeText;

        public IframePage(IPage page)
        {
            _page = page;

            // Method 1: Using FrameLocator (Recommended - Modern Approach)
            _iframe = page.FrameLocator("#iframe-id"); // or iframe[name='iframe-name']

            // Locators outside iframe
            _mainHeading = page.Locator("h1");

            // Locators inside iframe - chain with FrameLocator
            _iframeButton = _iframe.Locator("button#submit");
            _iframeInput = _iframe.Locator("input#username");
            _iframeText = _iframe.Locator(".result-text");
        }

        public async Task FillIframeFormAsync(string username)
        {
            await _iframeInput.FillAsync(username);
            await _iframeButton.ClickAsync();
        }

        public async Task<string> GetIframeResultTextAsync()
        {
            return await _iframeText.TextContentAsync() ?? string.Empty;
        }

        public async Task<string> GetMainHeadingAsync()
        {
            return await _mainHeading.TextContentAsync() ?? string.Empty;
        }
    }
}