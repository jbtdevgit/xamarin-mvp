using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin_MVP.Common.Login
{
    public class LoginPresenter : BasePresenter<ILoginView>, ILoginPresenter
    {
        private string _Username;
        private string _Password;
        private bool _pendingRequest;

        public LoginPresenter(ILoginView loginView) : base(loginView)
        {

        }

        public override void Destroy()
        {
            
        }

        public override Task Init()
        {
            BaseView?.OnLoginButtonEnabled(false);
            return Task.FromResult(0);
        }

        public override Task RestoreState(IList<string> savedStates)
        {
            throw new NotImplementedException();
        }

        public override IList<string> SaveStates()
        {
            throw new NotImplementedException();
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

        }
    }
}
