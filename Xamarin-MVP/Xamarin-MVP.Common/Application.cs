using DryIoc;
using Xamarin_MVP.Ioc;

namespace Xamarin_MVP.Common
{
    public abstract class Application : BaseApplication
    {
        protected Application() : base()
        { }

        protected override IContainerExtension CreateContainerExtension()
        {
            return new DryIocContainerExtension(new Container(CreateContainerRules()));
        }

        protected virtual Rules CreateContainerRules() => DryIocContainerExtension.DefaultRules;
    }
}
