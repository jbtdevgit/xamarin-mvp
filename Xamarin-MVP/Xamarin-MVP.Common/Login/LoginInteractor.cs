using System.Threading.Tasks;
using Xamarin_MVP.Common.Manager;
using Xamarin_MVP.Common.Services;

namespace Xamarin_MVP.Common.Login
{
    public class LoginInteractor : ILoginInteractor
    {
        readonly ILoginManager LoginManager;
        public LoginInteractor(ILoginManager loginManager)
        {
            LoginManager = loginManager;
        }


        public async Task<ValidateService<bool>> Login(string username, string password)
        {
            return await LoginManager.ValidateCredentials(username, password);
        }
    }
}
