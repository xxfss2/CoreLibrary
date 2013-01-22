using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiuzh.EFBase
{
    using System.Data.Objects.DataClasses;
    public class EntityReference<TInterface, TEntity> : IEntityReference<TInterface>
        where TInterface : class
        where TEntity : class, TInterface, IEntityWithRelationships
    {
        private readonly EntityReference<TEntity> _entityReference;
        private bool _isLoaded;

        public EntityReference(EntityReference<TEntity> entityReference)
        {
            _entityReference = entityReference;
            _isLoaded = entityReference.IsLoaded;
        }

        public TInterface Value
        {
            get
            {
                return _entityReference.Value;
            }
        }

        public bool IsLoaded
        {
            get
            {
                return _entityReference.IsLoaded || _isLoaded;
            }
        }

        public void Load()
        {
            try
            {
                _entityReference.Load();
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

        void IEntityReference<TInterface>.Attach(TInterface entity)
        {
        }
    }
}
