using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using LocalizedText = Uibasoft.Community.Cross.IoContainer.Unity.Localization.UnityIoC;

namespace Uibasoft.Community.Cross.IoContainer.Unity
{

    public class UnityIoC : IContainer
    {
        private const string RootContext = "rootcommunity";
        private const string RealAppContext = "realappcommunity";
        private const string TestAppContext = "testappcommunity";

        private readonly IUnityContainer _unityDefaulContainer;
        private readonly IDictionary<string, IUnityContainer> _containersDictionary;

        public IUnityContainer RootContainer => _containersDictionary[RootContext];
        public static UnityIoC IoCUnityManager { get; } = new UnityIoC();

        public UnityIoC()
        {

            //Create root container

            _containersDictionary = new Dictionary<string, IUnityContainer>();
            IUnityContainer rootUibasoftContainer = new UnityContainer();
            _containersDictionary.Add(RootContext, rootUibasoftContainer);

            var realAppContainer = rootUibasoftContainer.CreateChildContainer();
            _containersDictionary.Add(RealAppContext, realAppContainer);

            //Create container for testing, child of root container
            var fakeAppContainer = rootUibasoftContainer.CreateChildContainer();
            _containersDictionary.Add(TestAppContext, fakeAppContainer);

            _unityDefaulContainer = _containersDictionary[RealAppContext];

        }
        public UnityIoC(string nameDefault)

        {
            //Create root container

            _containersDictionary = new Dictionary<string, IUnityContainer>();
            IUnityContainer rootUibasoftContainer = new UnityContainer();
            _containersDictionary.Add(RootContext, rootUibasoftContainer);

            //Create container for real context, child of root container
            var realAppContainer = rootUibasoftContainer.CreateChildContainer();
            _containersDictionary.Add(RealAppContext, realAppContainer);

            //Create container for testing, child of root container
            var fakeAppContainer = rootUibasoftContainer.CreateChildContainer();
            _containersDictionary.Add(TestAppContext, fakeAppContainer);

            var defaultContainerConfigurationName = nameDefault;


            if (!_containersDictionary.ContainsKey(defaultContainerConfigurationName.ToLower()))

                throw new InvalidOperationException(LocalizedText.ErrorDefaultContainerContainsKey);

            _unityDefaulContainer = _containersDictionary[defaultContainerConfigurationName];

        }
        public virtual TServicio Resolver<TServicio>()
        {
            var result = _unityDefaulContainer.Resolve<TServicio>();
            return result;
        }
        public virtual object Resolver(Type type)
        {
            return _unityDefaulContainer.IsRegistered(type) ? _unityDefaulContainer.Resolve(type, null) : null;
        }
        public virtual IEnumerable<TServicio> ResolverAll<TServicio>()
        {
            return !_unityDefaulContainer.IsRegistered<TServicio>() ? null : _unityDefaulContainer.ResolveAll<TServicio>().AsEnumerable();
        }
        public virtual void RegisterType(Type type)
        {
            var container = _containersDictionary[RootContext];
            container?.RegisterType(type, new TransientLifetimeManager());

        }
        public virtual void RegisterInstance(Type type, object instance)
        {
            var container = _containersDictionary[RootContext];
            container?.RegisterInstance(type, instance);
        }
        public virtual void RegisterType(Type from, Type to)
        {
            var container = _containersDictionary[RootContext];
            container?.RegisterType(@from, to, new InjectionMember[0]);
        }
        public virtual void RegisterAllFromAssemblies(string name)
        {
            var container = _containersDictionary[RootContext];
            container?.RegisterTypes(
                AllClasses.FromAssembliesInBasePath(),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.ContainerControlled);

        }
        public virtual void RegisterType(Type from, Type to, LifetimeManager lifetimeManager)
        {
            var container = _containersDictionary[RootContext];
            container?.RegisterType(@from, to, lifetimeManager);

        }
        public virtual void PerformInjection(Type type, object existing)
        {
            var container = _containersDictionary[RootContext];
            container?.BuildUp(type, existing);

        }
    }
}
