using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiuzh.CoreBase.Infrastructure
{
    public static class Bootstrapper
    {
        static Bootstrapper()
        {
            try
            {
                IoC.InitializeWith(new DependencyResolverFactory());
            }
            catch (ArgumentException ex)
            {
            }


        }

        public static void Run()
        {
            IoC.ResolveAll<IBootstrapperTask>().ForEach(t => t.Execute());
        }
    }
}
