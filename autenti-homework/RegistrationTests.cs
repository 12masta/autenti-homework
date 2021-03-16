using System.Threading.Tasks;
using autenti_homework.Helpers;
using FluentAssertions;
using Xunit;

namespace autenti_homework
{
    public class RegistrationTests : BaseTest
    {
        [Fact]
        public async Task IsPageLoaded()
        {
            await Page.GoToAsync(TestConstants.Url + "/register");
            Page.Url.Should().Be(TestConstants.Url + "/register");
        }

        [Theory]
        [InlineData("example@email.com")]
        public async Task ShouldGoToTheNextStepOnClickWithValidEmail(string email)
        {
            await Page.GoToAsync(TestConstants.Url + "/register");
            await Page.TypeAsync("//*[@id='standard']", email);
            await Page.ClickAsync("//*[@type='submit']");

            Page.Url.Should().Be(TestConstants.Url + "/register/account-type");
        }
        
        [Theory]
        [InlineData("@email.com")]
        [InlineData("example@")]
        [InlineData("example@email.")]
        [InlineData("example@email")]
        [InlineData("exampleemail.com")]
        public async Task ShouldNotGoToTheNextStepOnClickWithInvalidEmail(string email)
        {
            await Page.GoToAsync(TestConstants.Url + "/register");
            await Page.TypeAsync("//*[@id='standard']", email);
            await Page.ClickAsync("//*[@type='submit']");

            Page.Url.Should().Be(TestConstants.Url + "/register");
        }
    }
}