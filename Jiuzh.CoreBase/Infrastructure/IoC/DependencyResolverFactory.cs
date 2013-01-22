using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiuzh.CoreBase.Infrastructure
{
    public class DependencyResolverFactory : IDependencyResolverFactory
    {
        private readonly Type _resolverType;
        protected string _resolverName;
       

        public DependencyResolverFactory(string resolverTypeName)
        {
            Check.Argument.IsNotEmpty(resolverTypeName, "resolverTypeName");

            _resolverType = Type.GetType(resolverTypeName, true, true);
        }

        public DependencyResolverFactory()
            : this(new ConfigurationManagerWrapper().AppSettings["dependencyResolverTypeName"])
        { }

        public IDependencyResolver CreateInstance()
        {
            
            return Activator.CreateInstance(_resolverType) as IDependencyResolver;
        }
    }
}
