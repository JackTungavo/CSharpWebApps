namespace MakersBnB.Tests;

using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

public class SignUpTests : PageTest
{
    [Test]
    public async Task SigningUpWithCorrectCredentials()
    {
        await Page.GotoAsync("http://localhost:5106/Users/New");
        await Page.GetByLabel("Username").FillAsync("username");
        await Page.GetByLabel("Email").FillAsync("email@email.com");
        await Page.GetByLabel("Password").FillAsync("secret");
        await Page.GetByRole(AriaRole.Button).ClickAsync();

        await Expect(Page).ToHaveTitleAsync(new Regex("Spaces - MakersBnB"));
    }
}
