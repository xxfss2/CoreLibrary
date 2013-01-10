﻿namespace Jiuzh.CoreBase
{
    using System.Collections.Generic;
    using System.Diagnostics;

    public static class CollectionExtension
    {
        //[DebuggerStepThrough]
        public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
        {
            return (collection == null) || (collection.Count == 0);
        }
    }
}