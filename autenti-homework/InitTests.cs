using System.Threading.Tasks;
using PlaywrightSharp;
using Xunit;

namespace autenti_homework
{
    public class InitTests
    {
        [Fact]
        public async Task TestInit()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(true);
            var page = await browser.NewPageAsync();
            await page.GoToAsync("https://autenti.com");
            await page.ScreenshotAsync(path: "screenshot.png");
        }
    }
}