using Allure.NUnit;
using Allure.Net.Commons;
using Microsoft.Playwright;
using Allure.NUnit.Attributes;
using PlaywrightTests.Pages;

namespace PlaywrightTests.Tests;

[Parallelizable(ParallelScope.All)] // All tests in this fixture run in parallel
[AllureNUnit]
[TestFixture]
public class UITests : BaseTestClass
{
    private HPCTestHarness? _testHarnessPage;
    [SetUp]
    public async Task TestSetup()
    {
        baseUrl = Environment.GetEnvironmentVariable("baseUrl") ?? "https://localhost:3000";
        await _page.GotoAsync(baseUrl);
        _testHarnessPage = new HPCTestHarness(_page);
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
            await _page.GotoAsync(baseUrl!);
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
}

