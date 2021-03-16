using System.Threading.Tasks;
using autenti_homework.Helpers;
using autenti_homework.PageObjects.Register.AccountType;
using PlaywrightSharp;

namespace autenti_homework.PageObjects.Register
{
    public class RegisterPage : IRegisterPage
    {
        private static string EmailFieldSelector => "//*[@id='standard']";
        private static string SubmitButtonSelector => "//*[@type='submit']";
        private static string Path => "/register";
        public string Url => _page.Url;

        private readonly IPage _page;

        public RegisterPage(IPage page)
        {
            _page = page;
        }

        public async Task<IRegisterPage> Load()
        {
            await _page.GoToAsync(TestConstants.Url + Path);
            return this;
        }

        public async Task<IRegisterPage> FillEmail(string email)
        {
            await _page.TypeAsync(EmailFieldSelector, email);
            return this;
        }

        public async Task<IAccountTypePage> ClickCreateFreeAccount()
        {
            await _page.ClickAsync(SubmitButtonSelector);
            await _page.WaitForNavigationAsync();
            return AccountTypePageFactory.Create(_page);
        }
    }
}