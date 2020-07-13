namespace Xamarin_MVP.Ioc
{
    public interface IContainerExtension<TContainer> : IContainerExtension
    {
        TContainer Instance { get; }
    }

    public interface IContainerExtension : IContainerProvider, IContainerRegistry
    {
        void FinalizeExtension();
    }
}
