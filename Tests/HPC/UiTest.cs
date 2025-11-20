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

    private static IEnumerable<TestCaseData> GetTestData()
    {
        var lines = File.ReadAllLines("./../../../Tests/Data/test.csv");

        // Skip header row
        for (int i = 1; i < lines.Length; i++)
        {
            var parts = lines[i].Split(',');
            yield return new TestCaseData(parts[0], parts[1], parts[2]);
        }
    }


    [SetUp]
    public async Task TestSetup()
    {
        baseUrl = Environment.GetEnvironmentVariable("baseurl") ?? "https://localhost:3000";
        Console.WriteLine("Navigating to : "+baseUrl);
    }

    [Test]
    [TestCaseSource(nameof(GetTestData))]
    [AllureSeverity(SeverityLevel.critical)] // Set severity level for the test
    [AllureOwner("John Doe")] // Assign an owner to the test
    [AllureLink("Documentation", "https://example.com/docs")] // Add a custom link
    [AllureIssue("BUG-456")] // Link to an issue
    public async Task SearchForPlaywright(string test_case, string name, string age)
    {
        await _page.GotoAsync(baseUrl);

        // Allure Step: Search for "Playwright"
        // await AllureApi.Step("Search for 'Playwright'", async () =>
        // {
        //     await _page.FillAsync("[name='q']", "Playwright");
        //     await _page.PressAsync("[name='q']", "Enter");
        //     await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        //     Assert.That(await _page.TitleAsync(), Does.Contain("Playwright"));
        // });
        // // Example of attaching a screenshot on failure (can be done in TearDown as well)
        // if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        // {
        //     var screenshotBytes = await _page.ScreenshotAsync();
        //     AllureApi.AddAttachment("Failed Test Screenshot", "image/png", screenshotBytes);
        // }
    }
}

