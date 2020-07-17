using System.Threading.Tasks;

namespace Xamarin_MVP.Common.APIService
{
    public interface ILoginAPIService
    {
        Task<bool> ValidateCredentials(string username, string password);
    }
}
