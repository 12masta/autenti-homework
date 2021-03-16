using System.Threading.Tasks;
using autenti_homework.PageObjects.Register.AccountType;

namespace autenti_homework.PageObjects.Register
{
    public interface IRegisterPage
    {
        string Url { get; }
        Task<IRegisterPage> Load();
        Task<IRegisterPage> FillEmail(string email);
        Task<IAccountTypePage> ClickCreateFreeAccount();
    }
}