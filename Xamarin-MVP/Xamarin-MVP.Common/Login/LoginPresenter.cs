﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin_MVP.Common.Login
{
    public class LoginPresenter : BasePresenter
    {
        public LoginPresenter(ILoginView loginView) : base(loginView)
        {

        }

        public override void Destroy()
        {
            
        }

        public override void Init()
        {
            
        }

        public override Task RestoreState(IList<string> savedStates)
        {
            throw new NotImplementedException();
        }

        public override IList<string> SaveStates()
        {
            throw new NotImplementedException();
        }
    }
}
