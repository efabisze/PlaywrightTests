using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTests.Pages
{
    public class TestHarnessPage
    {
        private readonly IPage _page;

        // Locators
        private readonly string _usernameInput = "#username";
        private readonly string _passwordInput = "#password";
        private readonly string _loginButton = "#loginButton";
        private readonly string _resultText = "#result";

        public TestHarnessPage(IPage page)
        {
            _page = page;
        }

        public async Task FillInPayload()
        {
            
        }

        public async Task getResults()
        {

        }

        public async Task<string> FillInIframe()
        {

        }
    }
}
