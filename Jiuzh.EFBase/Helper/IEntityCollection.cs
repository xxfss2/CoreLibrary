using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiuzh.EFBase
{
    using System.Collections;
    public interface IEntityCollection<TInterface> : ICollection, IEnumerable<TInterface> where TInterface : class
    {
        bool IsLoaded { get; }
        void Load();
        void Clear();
        bool Remove(TInterface entity);
        void Add(TInterface entity);
    }
}
