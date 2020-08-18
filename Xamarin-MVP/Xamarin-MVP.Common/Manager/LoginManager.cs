using System.Threading.Tasks;
using Xamarin_MVP.Common.APIService;
using Xamarin_MVP.Common.Constants;
using Xamarin_MVP.Common.Services;

namespace Xamarin_MVP.Common.Manager
{
    public class LoginManager : ILoginManager
    {
        readonly ILoginAPIService LoginAPIService;

        public LoginManager(ILoginAPIService loginAPIService)
        {
            LoginAPIService = loginAPIService;
        }


        public async Task<ValidateService<bool>> ValidateCredentials(string username, string password)
        {
            bool result = await LoginAPIService.ValidateCredentials(username, password);

            if (result)
            {
                return new ValidateService<bool>(APIResponseEnum.ValidCredentials);
            }
            else
            {
                return new ValidateService<bool>(APIResponseEnum.InvalidCredentials);
            }

        }
    }
}
