using PlaywrightSharp;

namespace autenti_homework.PageObjects.Register.AccountType
{
    public static class AccountTypePageFactory
    {
        public static IAccountTypePage Create(IPage page)
        {
            return new AccountTypePage(page);
        }
    }
}