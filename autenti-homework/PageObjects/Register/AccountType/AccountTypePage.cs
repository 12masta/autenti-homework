using PlaywrightSharp;

namespace autenti_homework.PageObjects.Register.AccountType
{
    public class AccountTypePage : IAccountTypePage
    {
        private readonly IPage _page;

        public AccountTypePage(IPage page)
        {
            _page = page;
        }

        public string Url => _page.Url;
    }
}