using Xamarin_MVP.Common.Constants;

namespace Xamarin_MVP.Common.Services
{
    public class ValidateService<T>
    {
        public readonly APIResponseEnum ErrorResponse;
        public readonly T Data;

        public ValidateService(T data)
        {
            Data = data;
            ErrorResponse = APIResponseEnum.None;
        }

        public ValidateService(APIResponseEnum error)
        {
            Data = default(T);
            ErrorResponse = error;
        }
    }
}
