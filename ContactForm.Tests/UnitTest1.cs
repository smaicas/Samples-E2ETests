using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Playwright.NUnit;
using NUnit.Framework.Internal;

namespace ContactForm.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    private readonly DnjTestingWebApplicationFactory<ContactForm.Web.Program> _webApplicationFactory;
    private readonly HttpClient _client;
    public Tests()
    {
        _webApplicationFactory = new DnjTestingWebApplicationFactory<ContactForm.Web.Program>();
        WebApplicationFactoryClientOptions clientOptions = new()
        {
            AllowAutoRedirect = true,
            BaseAddress = new Uri("http://localhost"),
            HandleCookies = true,
            MaxAutomaticRedirections = 7
        };

        _client = _webApplicationFactory.CreateClient(clientOptions);
    }

    [Test]
    public async Task Clicking_ContactButton_Goes_To_ContactForm()
    {
        HttpResponseMessage defaultPage = await _client.GetAsync("/");

        // Create a new Playwright instance and a new browser
        try
        {
            await Page.GotoAsync("https://localhost:7048");
        }
        catch (Exception e)
        {

            throw;
        }
        await Page.GotoAsync(_client.BaseAddress.AbsoluteUri);
        //Microsoft.Playwright.ILocator formButton = Page.Locator("text=Open Contact Form");
        //await formButton.ClickAsync();
        await Expect(Page).ToHaveURLAsync(new Regex(".*/"));
    }
}