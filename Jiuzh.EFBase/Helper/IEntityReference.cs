
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiuzh.EFBase
{
    public interface IEntityReference<TInterface> where TInterface : class
    {
        TInterface Value { get; }
        bool IsLoaded { get; }
        void Load();
        void Attach(TInterface entity);
    }
}
