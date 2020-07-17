using System.Threading.Tasks;

namespace Xamarin_MVP.Common.APIService
{
    public class LoginAPIService : ILoginAPIService
    {
        public Task<bool> ValidateCredentials(string username, string password)
        {
            if(username.Equals("test") && password.Equals("test"))
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
