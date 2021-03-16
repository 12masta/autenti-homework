using System.Threading.Tasks;
using autenti_homework.Helpers;
using autenti_homework.PageObjects.Register;
using FluentAssertions;
using Xunit;

namespace autenti_homework
{
    public class RegistrationTests : BaseTest
    {
        [Fact]
        public async Task IsPageLoaded()
        {
            var registerPage = await RegisterPageFactory.Create(Page).Load();

            registerPage.Url.Should().Be(TestConstants.Url + "/register");
        }

        [Theory]
        [InlineData("example@email.com")]
        public async Task ShouldGoToTheNextStepOnClickWithValidEmail(string email)
        {
            var registerPage = await RegisterPageFactory.Create(Page).Load();
            await registerPage.FillEmail(email);
            var accountTypePage = await registerPage.ClickCreateFreeAccount();

            accountTypePage.Url.Should().Be(TestConstants.Url + "/register/account-type");
        }

        [Theory]
        [InlineData("@email.com")]
        [InlineData("example@")]
        [InlineData("example@email.")]
        [InlineData("example@email")]
        [InlineData("exampleemail.com")]
        public async Task ShouldNotGoToTheNextStepOnClickWithInvalidEmail(string email)
        {
            var registerPage = await RegisterPageFactory.Create(Page).Load();
            await registerPage.FillEmail(email);
            var accountTypePage = await registerPage.ClickCreateFreeAccount();

            accountTypePage.Url.Should().Be(TestConstants.Url + "/register");
        }
    }
}