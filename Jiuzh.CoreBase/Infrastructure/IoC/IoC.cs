using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Jiuzh.CoreBase.Infrastructure
{
    using System.Diagnostics;
    
    public static  class IoC
    {
        private static  IDependencyResolver _resolver;

        /// <summary>
        /// 注册Unity Configuration File
        /// </summary>
        /// <param name="strFile"></param>
        /// <returns>返回false,表示文件不存在</returns>
        public static bool RegisterUCF(string strFile)
        {
            bool bret = false;
            if (File.Exists(strFile))
            {
                _resolver.LoadConfiguration(strFile);
                bret = true;
            }
            return bret;
        }

       
       
        //public 

        ////[DebuggerStepThrough]
        /// <summary>
        /// 初始化Ioc
        /// 
        /// </summary>
        /// <param name="factory"></param>
        public static void InitializeWith(IDependencyResolverFactory factory)
        {
            
            _resolver = factory.CreateInstance();
        }

        ////[DebuggerStepThrough]
        public static void Register<T>(T instance)
        {
            _resolver.Register(instance);
        }

        ////[DebuggerStepThrough]
        public static void Inject<T>(T existing)
        {
            _resolver.Register(existing);
        }

        ////[DebuggerStepThrough]
        public static T Resolve<T>(Type type)
        {
            return _resolver.Resolve<T>(type);
        }

        ////[DebuggerStepThrough]
        public static T Resolve<T>(Type type, string name)
        {
            return _resolver.Resolve<T>(type, name);
        }

        ////[DebuggerStepThrough]
        public static T Resolve<T>()
        {
            return _resolver.Resolve<T>();
        }

        ////[DebuggerStepThrough]
        public static T Resolve<T>(string name)
        {
            return _resolver.Resolve<T>(name);
        }

        ////[DebuggerStepThrough]
        public static IEnumerable<T> ResolveAll<T>()
        {
            return _resolver.ResolveAll<T>();
        }

        ////[DebuggerStepThrough]
        public static void Reset()
        {
            if (_resolver != null)
            {
                _resolver.Dispose();
            }
        }

      


    }
}
