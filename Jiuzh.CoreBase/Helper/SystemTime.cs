namespace Jiuzh.CoreBase
{
    using System;

    public static class SystemTime
    {
        public static Func<DateTime> Now = () => DateTime.UtcNow;
    }
}