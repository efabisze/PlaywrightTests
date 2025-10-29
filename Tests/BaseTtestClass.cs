using Microsoft.Playwright;

namespace PlaywrightTests.Tests;

[Parallelizable(ParallelScope.Children)]
public class BaseTestClass
{
    protected IPlaywright _playwright;
    protected IBrowser _browser;
    protected IPage _page;
    protected IBrowserContext _context;
    protected string baseUrl = null!;

    [OneTimeSetUp]
    public async Task OneTimeSetup()
    {
        bool headless = Environment.GetEnvironmentVariable("headless") != "false";

        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new() { Headless = headless });
    }

    [SetUp]
    public async Task Setup()
    {
        // Create a new browser context for each test (isolated cookies/storage)
        _context = await _browser.NewContextAsync();
        _page = await _context.NewPageAsync();
    }

    [TearDown]
    public async Task Teardown()
    {
        await _page?.CloseAsync();
        await _context?.CloseAsync();
    }

    [OneTimeTearDown]
    public async Task OneTimeTeardown()
    {
        await _browser?.CloseAsync();
        _playwright?.Dispose();
    }
}