using System.Data.Objects.DataClasses;

using Jiuzh.CoreBase;

namespace Jiuzh.EFBase
{
    public static class EntityHelper
    {
        public static void EnsureEntityCollection<TInterface, TEntity>(ref EntityCollection<TInterface, TEntity> entityCollection, EntityCollection<TEntity> originalEntityCollection)
            where TInterface : class
            where TEntity : class, IEntityWithRelationships, TInterface
        {
            
            if (entityCollection != null) return;

            Check.Argument.IsNotNull(originalEntityCollection, "orginalEntityCollection");
            entityCollection = new EntityCollection<TInterface, TEntity>(originalEntityCollection);
        }

        public static void EnsureEntityCollectionLoaded<TInterface>(IEntityCollection<TInterface> entityCollection)
            where TInterface:class
        {
            Check.Argument.IsNotNull(entityCollection,"entityCollection");

            if(entityCollection==null|| entityCollection.IsLoaded) return;
            entityCollection.Load();
        }

        public static void EnsureEntityReference<TInterface, TEntity>(ref EntityReference<TInterface, TEntity> entityRef, EntityReference<TEntity> originalRef)
            where TInterface : class
            where TEntity : class, IEntityWithRelationships, TInterface
        {
            if (entityRef != null) return;
            Check.Argument.IsNotNull(originalRef, "orginalEntityRef");
            entityRef = new EntityReference<TInterface, TEntity>(originalRef);
        }

        public static void EnsureEntityReferenceLoaded<TInterface>(IEntityReference<TInterface> entityRef)
            where TInterface : class
        {
            Check.Argument.IsNotNull(entityRef, "entityRef");
            if (entityRef == null || entityRef.IsLoaded) return;
            entityRef.Load();
        }
    }
}