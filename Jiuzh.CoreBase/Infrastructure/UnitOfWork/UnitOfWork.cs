namespace Jiuzh.CoreBase.Infrastructure
{
    using System.Diagnostics;

    public static class UnitOfWork
    {
        [DebuggerStepThrough]
        public static IUnitOfWork Begin()
        {
            return IoC.Resolve<IUnitOfWork>();
        }
        public static IUnitOfWork Begin(string key)
        {
            return IoC.Resolve<IUnitOfWork>(key);
        }
    }
}