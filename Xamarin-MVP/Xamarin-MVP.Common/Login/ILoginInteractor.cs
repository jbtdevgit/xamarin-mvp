using System.Threading.Tasks;
using Xamarin_MVP.Common.Services;

namespace Xamarin_MVP.Common.Login
{
    public interface ILoginInteractor
    {
        Task<ValidateService<bool>> Login(string username, string password);
    }
}
