using Xamarin_MVP.Common.Constants;

namespace Xamarin_MVP.Common.Services
{
    public class ValidateService<T>
    {
        public readonly ErrorResponseEnum ErrorResponse;
        public readonly T Data;

        public ValidateService(T data)
        {
            Data = data;
            ErrorResponse = ErrorResponseEnum.None;
        }

        public ValidateService(ErrorResponseEnum error)
        {
            Data = default(T);
            ErrorResponse = error;
        }
    }
}
