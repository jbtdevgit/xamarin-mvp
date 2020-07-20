using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Content.PM;
using Xamarin_MVP.Common;
using System;

namespace Xamarin_MVP.Android.Activities
{
    public abstract class MainActivity<T> : AppCompatActivity, IBaseView where T : BasePresenter
    {
        protected T Presenter { get; set; }
        private readonly string PresenterStateKey = "PRESENTER_STATE_KEY";
        protected abstract IBaseView BaseView { get; }
        protected abstract T GetPresenter();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        protected void CreatePresenter(Bundle savedInstanceState)
        {
            if(GetRetainedPresenter() != null)
            {
                Presenter = GetRetainedPresenter();
                Presenter.BaseView = BaseView;
            }
            else
            {
                Presenter = GetPresenter();

                if(Presenter == null)
                {
                    throw new NotImplementedException();
                }

                if (savedInstanceState != null)
                {
                    Presenter.RestoreState(savedInstanceState.GetStringArrayList(PresenterStateKey));
                }
                else
                {
                    Presenter.Init();
                }

            }
        }

        protected override void OnStart()
        {
            base.OnStart();
            if(Presenter == null)
            {
                throw new NotImplementedException();
            }
        }

        protected T GetRetainedPresenter()
        {
            if(this.LastCustomNonConfigurationInstance != null)
            {
                CustomNonConfigurationWrapper<T> wrapper = (CustomNonConfigurationWrapper<T>)this.LastCustomNonConfigurationInstance;
                return wrapper.Target;
            }

            return default(T);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            Presenter.BaseView = null;
            if (!IsChangingConfigurations)
            {
                Presenter.Destroy();
            }
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutStringArrayList(PresenterStateKey, Presenter.SaveStates());
        }

        public abstract void OnNetworkError();

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum]Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class CustomNonConfigurationWrapper<T> : Java.Lang.Object
    {
        public readonly T Target;

        public CustomNonConfigurationWrapper(T target)
        {
            Target = target;
        }
    }
}