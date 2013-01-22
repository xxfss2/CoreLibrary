namespace Jiuzh.Infrastructure.EnterpriseLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Configuration;
    using System.Diagnostics;
    using System.Web;

    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using Jiuzh.CoreBase;
    using Jiuzh.CoreBase.Infrastructure ;

    public class  UnityDependencyResolver : DisposableResource, IDependencyResolver
    {

        private readonly IUnityContainer _container = null;
        //protected string _fileName;
        private string[] _files;
       // protected abstract void InitPath();

        public void LoadConfiguration(string filename)
        {
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = filename };
            Configuration configuration =
                ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            var unitySection1 = (UnityConfigurationSection)configuration.GetSection("unity");
            
            
            _container.LoadConfiguration(unitySection1);
        }

       //[DebuggerStepThrough]
        public UnityDependencyResolver()
            : this(new UnityContainer())
        {

            UnityConfigurationSection configuration = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            _container.LoadConfiguration(configuration);
            //ExeConfigurationFileMap infraFileMap = null;
            //UnityConfigurationSection infraConfig = null;
            //foreach (string filename in _files)
            //{

            //    infraFileMap = new ExeConfigurationFileMap();
                
            //    //  InitPath();
            //    infraFileMap.ExeConfigFilename = filename;

            //    infraConfig = (UnityConfigurationSection)ConfigurationManager.
            //        OpenMappedExeConfiguration(infraFileMap, ConfigurationUserLevel.None).GetSection("unity");
            //    if (_container != null)
            //    {
            //        _container.LoadConfiguration(infraConfig);
            //    }
               
            //}
        }

       //[DebuggerStepThrough]
        public UnityDependencyResolver(IUnityContainer container)
        {
            Check.Argument.IsNotNull(container, "container");

            _container = container;
        }

       //[DebuggerStepThrough]
        public void Register<T>(T instance)
        {
            Check.Argument.IsNotNull(instance, "instance");

            _container.RegisterInstance(instance);
        }

       //[DebuggerStepThrough]
        public void Inject<T>(T existing)
        {
            Check.Argument.IsNotNull(existing, "existing");

            _container.BuildUp(existing);
        }

       //[DebuggerStepThrough]
        public T Resolve<T>(Type type)
        {
            Check.Argument.IsNotNull(type, "type");

            return (T)_container.Resolve(type);
        }

       //[DebuggerStepThrough]
        public T Resolve<T>(Type type, string name)
        {
            Check.Argument.IsNotNull(type, "type");
            Check.Argument.IsNotEmpty(name, "name");

            return (T)_container.Resolve(type, name);
        }

       //[DebuggerStepThrough]
        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

       //[DebuggerStepThrough]
        public T Resolve<T>(string name)
        {
            Check.Argument.IsNotEmpty(name, "name");

            return _container.Resolve<T>(name);
        }

       //[DebuggerStepThrough]
        public IEnumerable<T> ResolveAll<T>()
        {
            IEnumerable<T> namedInstances = _container.ResolveAll<T>();
            T unnamedInstance = default(T);

            try
            {
                unnamedInstance = _container.Resolve<T>();
            }
            catch (ResolutionFailedException)
            {
                //When default instance is missing
            }

            if (Equals(unnamedInstance, default(T)))
            {
                return namedInstances;
            }

            return new ReadOnlyCollection<T>(new List<T>(namedInstances) { unnamedInstance });
        }

       //[DebuggerStepThrough]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _container.Dispose();
            }

            base.Dispose(disposing);
        }

        public IUnityContainer RegisterType<TFrom, TTo>(LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers) where TTo : TFrom
        {
            return _container.RegisterType<TFrom, TTo>(lifetimeManager, injectionMembers);

        }
        public  IUnityContainer RegisterType<TFrom, TTo>(string name, params InjectionMember[] injectionMembers) where TTo : TFrom
        {
            return _container.RegisterType<TFrom, TTo>(name, injectionMembers);
        }
    }
}