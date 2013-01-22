using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiuzh.CoreBase.Repository
{
    using Jiuzh.CoreBase.DomainObjects;
    public interface IStampedRepository<TEntity> : IRepository<TEntity> where TEntity : IStampedEntity
    {
        TEntity FindById(int id);
        ICollection<TEntity> FindByUser(int userId);
    }
}
