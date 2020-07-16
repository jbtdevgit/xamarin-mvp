using DryIoc;
using System;
using System.Linq;

namespace Xamarin_MVP.Ioc
{
    public class DryIocContainerExtension : IContainerExtension<IContainer>
    {
        private DryIocScopedProvider _currentScope;

        public static Rules DefaultRules => Rules.Default.WithConcreteTypeDynamicRegistrations()
                                                         .With(Made.Of(FactoryMethod.ConstructorWithResolvableArguments))
                                                         .WithFuncAndLazyWithoutRegistration()
                                                         .WithTrackingDisposableTransients()
                                                         .WithoutFastExpressionCompiler()
                                                         .WithDefaultIfAlreadyRegistered(IfAlreadyRegistered.Replace);

        public IContainer Instance { get; }

        public DryIocContainerExtension() : this(new Container(DefaultRules))
        {
        }

        public DryIocContainerExtension(IContainer container)
        {
            Instance = container;
            Instance.RegisterInstanceMany(new[]
            {
                typeof(IContainerExtension),
                typeof(IContainerProvider)
            },
            this);
        }

        public IScopedProvider CurrentScope => _currentScope;

        public void FinalizeExtension()
        {
        }

        public IContainerRegistry Register(Type from, Type to)
        {
            Instance.Register(from, to);
            return this;
        }

        public IContainerRegistry Register(Type T)
        {
            Instance.Register(T);
            return this;
        }

        public IContainerRegistry Register(Type from, Type to, string name)
        {
            Instance.Register(from, to, serviceKey: name);
            return this;
        }

        public IContainerRegistry Register(Type type, Func<object> factoryMethod)
        {
            Instance.RegisterDelegate(type, r => factoryMethod());
            return this;
        }

        public IContainerRegistry Register(Type type, Func<IContainerProvider, object> factoryMethod)
        {
            Instance.RegisterDelegate(type, factoryMethod);
            return this;
        }

        public IContainerRegistry RegisterSingleton(Type from, Type to)
        {
            Instance.Register(from, to, Reuse.Singleton);
            return this;
        }

        public IContainerRegistry RegisterSingleton(Type T)
        {
            Instance.Register(T, Reuse.Singleton);
            return this;
        }

        public IContainerRegistry RegisterSingleton(Type type, Func<object> factoryMethod)
        {
            Instance.RegisterDelegate(type, r => factoryMethod(), Reuse.Singleton);
            return this;
        }

        public IContainerRegistry RegisterSingleton(Type type, Func<IContainerProvider, object> factoryMethod)
        {
            Instance.RegisterDelegate(type, factoryMethod, Reuse.Singleton);
            return this;
        }

        public object Resolve(Type type) => Resolve(type, Array.Empty<(Type, object)>());

        public object Resolve(Type type, params (Type Type, object Instance)[] paramaters)
        {
            IResolverContext container = _currentScope?.ResolverContext ?? Instance;
            return container.Resolve(type, args: paramaters.Select(p => p.Instance).ToArray());
        }

        public object Resolve(Type type, string name) => Resolve(type, name, Array.Empty<(Type, object)>());

        public object Resolve(Type type, string name, params (Type Type, object Instance)[] parameters)
        {
            IResolverContext container = _currentScope?.ResolverContext ?? Instance;
            return container.Resolve(type, name, args: parameters.Select(p => p.Instance).ToArray());
        }

        public virtual IScopedProvider CreateScope() =>
            CreateScopeInternal();

        protected IScopedProvider CreateScopeInternal()
        {
            IResolverContext resolver = Instance.OpenScope();
            _currentScope = new DryIocScopedProvider(resolver);
            return _currentScope;
        }
        private class DryIocScopedProvider : IScopedProvider
        {
            public IResolverContext ResolverContext { get; private set; }


            public DryIocScopedProvider(IResolverContext resolverContext)
            {
                ResolverContext = resolverContext;
            }

            public bool IsAttached { get; set; }

            public IScopedProvider CurrentScope => this;
            public IScopedProvider CreateScope() => this;

            public void Dispose()
            {
                ResolverContext.Dispose();
                ResolverContext = null;
            }

            public object Resolve(Type type) => Resolve(type, Array.Empty<(Type, object)>());
            public object Resolve(Type type, string name) => Resolve(type, name, Array.Empty<(Type, object)>());

            public object Resolve(Type type, params (Type Type, object Instance)[] paramaters)
            {
                return ResolverContext.Resolve(type, args: paramaters.Select(p => p.Instance).ToArray());
            }


            public object Resolve(Type type, string name, params (Type Type, object Instance)[] parameters)
            {
                return ResolverContext.Resolve(type, name, args: parameters.Select(p => p.Instance).ToArray());
            }
        }
    }
}
