using Allure.NUnit;
using Allure.Net.Commons;
using Microsoft.Playwright;
using Allure.NUnit.Attributes;
using Microsoft.Playwright.NUnit;
using Microsoft.VisualBasic;

namespace PlaywrightTests.Tests
{



    // Apply the AllureNUnit attribute to enable Allure reporting for this test fixture
    [AllureNUnit]
    [TestFixture]
    public class UITests
    {
        private IPlaywright _playwright = null!;
        private IBrowser _browser = null!;
        private IPage _page = null!;
        private string? _baseUrl;

        [SetUp]
        public async Task Setup()
        {
            bool headless = Environment.GetEnvironmentVariable("headless") != "false";

            _baseUrl = Environment.GetEnvironmentVariable("baseUrl") ?? "https://localhost:3000";

            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = headless,
                Channel = "msedge"
            });
            _page = await _browser!.NewPageAsync();
            TestContext.Progress.WriteLine("Local Setup:!!!!!!!!!!");
        }


        [Test]
        [AllureSeverity(SeverityLevel.critical)] // Set severity level for the test
        [AllureOwner("John Doe")] // Assign an owner to the test
        [AllureLink("Documentation", "https://example.com/docs")] // Add a custom link
        [AllureIssue("BUG-456")] // Link to an issue
        public async Task SearchForPlaywright()
        {
            // Allure Step: Navigate to Google
            await AllureApi.Step("Navigate to Google", async () =>
            {
                await _page.GotoAsync(_baseUrl!);
                Assert.That(await _page.TitleAsync(), Is.EqualTo("React • TodoMVC"));
            });


            // Allure Step: Search for "Playwright"
            await AllureApi.Step("Search for 'Playwright'", async () =>
            {
                await _page.FillAsync("[name='q']", "Playwright");
                await _page.PressAsync("[name='q']", "Enter");
                await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
                Assert.That(await _page.TitleAsync(), Does.Contain("Playwright"));
            });


            // Example of attaching a screenshot on failure (can be done in TearDown as well)
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var screenshotBytes = await _page.ScreenshotAsync();
                AllureApi.AddAttachment("Failed Test Screenshot", "image/png", screenshotBytes);
            }
        }


        /*   [TearDown]
           public async Task Teardown()
           {
               await _browser.CloseAsync();
               _playwright.Dispose();
           }*/
    }
}
