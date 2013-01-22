using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiuzh.CoreBase.Infrastructure
{
    public interface IDependencyResolver : IDisposable
    {
        void LoadConfiguration(string filename);

        void Register<T>(T instance);

        void Inject<T>(T existing);

        T Resolve<T>(Type type);

        T Resolve<T>(Type type, string name);

        T Resolve<T>();

        T Resolve<T>(string name);

        IEnumerable<T> ResolveAll<T>();
    }
}
