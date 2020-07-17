using System.Threading.Tasks;

namespace Xamarin_MVP.Common.Login
{
    public interface ILoginPresenter
    {
        void UpdateUsername(string username);
        void UpdatePassword(string password);
        Task Login();
    }
}
