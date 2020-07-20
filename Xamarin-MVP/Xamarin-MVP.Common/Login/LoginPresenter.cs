using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin_MVP.Common.Constants;
using Xamarin_MVP.Common.Manager;
using Xamarin_MVP.Common.Services;

namespace Xamarin_MVP.Common.Login
{
    public class LoginPresenter : BasePresenter<ILoginView>, ILoginPresenter
    {
        string _Username;
        string _Password;
        bool _pendingRequest;
        readonly ILoginInteractor LoginInteractor;

        public LoginPresenter(ILoginView loginView, ILoginInteractor loginInteractor) : base(loginView)
        {
            LoginInteractor = loginInteractor;
        }

        public override void Destroy()
        {
            
        }

        public override Task Init()
        {
            BaseView?.OnLoginButtonEnabled(false);
            return Task.FromResult(0);
        }

        public override async Task RestoreState(IList<string> savedStates)
        {
            _Username = savedStates[0];
            _Password = savedStates[1];
            _pendingRequest = JsonConvert.DeserializeObject<bool>(savedStates[2]);
            if (_pendingRequest)
            {
                await Login();
            }
        }

        public override IList<string> SaveStates()
        {
            List<string> states = new List<string>
            {
                _Username,
                _Password,
                JsonConvert.SerializeObject(_pendingRequest)
            };

            return states;
        }

        public void UpdatePassword(string password)
        {
            _Password = password;
            ValidateInput();
        }

        public void UpdateUsername(string username)
        {
            _Username = username;
            ValidateInput();
        }

        private void ValidateInput()
        {
            BaseView?.OnLoginButtonEnabled(HasValidInput());
        }

        private bool HasValidInput()
        {
            return !string.IsNullOrWhiteSpace(_Username) && !string.IsNullOrWhiteSpace(_Password);
        }

        public async Task Login()
        {
            if (!HasValidInput())
            {
                return;
            }

            BaseView?.ClearError();
            _pendingRequest = true;
            BaseView?.OnWaiting();
            ValidateService<bool> result = await LoginInteractor.Login(_Username, _Password);
            BaseView?.OnWaiting();
            _pendingRequest = false;

            if (result.ErrorResponse.Equals(ErrorResponseEnum.None))
            {
                BaseView?.GoToNextScreen();
            }
            else if (result.ErrorResponse.Equals(ErrorResponseEnum.InvalidCredentials))
            {
                BaseView?.OnInvalidCredentials("Invalid Credentials");
            }
            

        }
    }
}
