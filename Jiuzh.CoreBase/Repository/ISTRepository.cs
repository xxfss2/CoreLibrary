using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiuzh.CoreBase.Repository
{
    using Jiuzh.CoreBase.DomainObjects;
    public interface ISTRepository<TEntity> : IRepository<TEntity> where TEntity : ISTEntity
    {
        TEntity FindById(int id);
        ICollection<TEntity> FindAll();
    }
}
