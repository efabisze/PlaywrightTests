namespace PlaywrightTests.Pages;

using Microsoft.Playwright;

public class HPCTestHarness(IPage page)
{
    private readonly IPage _page = page;
    private readonly ILocator _emailInput = page.Locator("#email");
    private readonly ILocator _passwordInput = page.Locator("#password");
    private readonly ILocator _loginButton = page.Locator("button[type='submit']");

    public async Task LoginAsync(string email, string password)
    {
        await _emailInput.FillAsync(email);
        await _passwordInput.FillAsync(password);
        await _loginButton.ClickAsync();
    }
}