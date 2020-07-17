using System.Threading.Tasks;
using Xamarin_MVP.Common.Services;

namespace Xamarin_MVP.Common.Manager
{
    public interface ILoginManager
    {
        Task<ValidateService<bool>> ValidateCredentials(string username, string password);
    }
}
