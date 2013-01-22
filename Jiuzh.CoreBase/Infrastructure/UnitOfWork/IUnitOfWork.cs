namespace Jiuzh.CoreBase.Infrastructure
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}