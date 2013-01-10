using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiuzh.EFBase
{
    using System.Data.Objects.DataClasses;
    using System.Collections;
    using System.Threading;
    using Jiuzh.CoreBase;
    public class EntityCollection<TInterface, TEntity> : IEntityCollection<TInterface>
        where TInterface : class
        where TEntity : class, TInterface, IEntityWithRelationships
    {
       
        private readonly EntityCollection<TEntity> _entityCollection;
        private bool _isLoaded;
        private object _syncRoot;


        public int Count
        {
            get
            {
              return  _entityCollection.Count;
            }
        }

        public virtual bool IsSynchronized
        {
            get
            {
                
                return false;
            }
        }

        public virtual object SyncRoot
        {
            get
            {
                
                if (_syncRoot == null)
                {
                    
                    Interlocked.CompareExchange(ref _syncRoot, new object(), null);
                }
                return _syncRoot;
            }
        }

        public EntityCollection(EntityCollection<TEntity> entityCollection)
        {
            _isLoaded = entityCollection.IsLoaded;
            _entityCollection = entityCollection;
        }

        void IEntityCollection<TInterface>.Clear()
        {
        }

      

       // public int Count { get { return _entityCollection.Count; } }

        public bool IsReadOnly { get { return _entityCollection.IsReadOnly; } }

        public bool IsLoaded
        {
            get
            {
                try
                {
                    return _entityCollection.IsLoaded || _isLoaded;
                }
                catch (ObjectDisposedException ex)
                {
                    //Log
                    return _isLoaded;
                }
            }
        }

        public void Load()
        {
            try
            {
                _entityCollection.Load();
            }
            catch (ObjectDisposedException ex)
            {
                //Log
                _isLoaded = true;
            }
            catch (InvalidOperationException ex)
            {
                //Log
                _isLoaded = true;
            }
        }
        public IQueryable<TEntity> CreateSourceQuery()
        {
            IQueryable<TEntity> query;
            try
            {
                query = _entityCollection.CreateSourceQuery();
            }
            catch (ObjectDisposedException ex)
            {
                //Log
                query = _entityCollection.AsQueryable();
            }
            catch (InvalidOperationException ex)
            {
                //Log
                query = _entityCollection.AsQueryable();
            }
            return query ?? _entityCollection.AsQueryable();
        }


        public bool Contains(TInterface entity)
        {
            return _entityCollection.Contains(entity as TEntity);
        }

        public void Add(TInterface entity)
        {
            _entityCollection.Add(entity as TEntity);
        }

        public bool Remove(TInterface entity)
        {
            return _entityCollection.Remove(entity as TEntity);
        }

        public void Clear()
        {
            _entityCollection.Clear();
        }

        public void CopyTo(Array array, int arrayIndex)
        {
            Check.Argument.IsNotNull(array, "array");
            Check.Argument.IsNotOutOfRange(arrayIndex, 0, int.MaxValue, "arrayIndex");

            var entityesArray = array.Cast<TEntity>().ToArray();
            CopyTo(entityesArray, arrayIndex);
        }

        public void CopyTo(TEntity[] array, int arrayIndex)
        {
            Check.Argument.IsNotNull(array, "array");
            Check.Argument.IsNotOutOfRange(arrayIndex, 0, int.MaxValue, "arrayIndex");

            _entityCollection.CopyTo(array, arrayIndex);
        }

        public IEnumerator<TInterface> GetEnumerator()
        {
            //return _entityCollection.GetEnumerator();
            foreach (var entity in _entityCollection)
            {
                yield return entity;
            }
        }

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion 

        #region ICollectionMembers

        void ICollection.CopyTo(Array array, int arrayIndex)
        {
            CopyTo(array, arrayIndex);
        }

        int ICollection.Count
        {
            get
            {
                return Count;
            }
        }

        bool ICollection.IsSynchronized
        {
            get
            {
                return IsSynchronized;
            }
        }

        object ICollection.SyncRoot
        {
            get
            {
                return SyncRoot;
            }
        }

        #endregion

        #region IEnumerable<TInterface> Members

        IEnumerator<TInterface> IEnumerable<TInterface>.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

    }
}
