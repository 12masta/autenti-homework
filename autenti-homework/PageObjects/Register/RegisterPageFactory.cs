using PlaywrightSharp;

namespace autenti_homework.PageObjects.Register
{
    public static class RegisterPageFactory
    {
        public static IRegisterPage Create(IPage page)
        {
            return new RegisterPage(page);
        }
    }
}