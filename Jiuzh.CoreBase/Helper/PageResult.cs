using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiuzh.CoreBase
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    public class PageResult<T>
    {
        private readonly ReadOnlyCollection<T> _result;
        private readonly int _total;

        public PageResult(IEnumerable<T> result, int total)
        {
            Check.Argument.IsNotNull(result, "result");
            Check.Argument.IsNotNegative(total, "total");

            _result = new ReadOnlyCollection<T>(new List<T>(result));
            _total = total;
        }

        public PageResult()
            : this(new List<T>(), 0)
        {

        }

        public ICollection<T> Result
        {
            //[DebuggerStepThrough]
            get
            {
                return _result;
            }
        }

        public int Total
        {
            //[DebuggerStepThrough]
            get
            {
                return _total;
            }
        }

        public bool IsEmpty
        {
            //[DebuggerStepThrough]
            get
            {
                return _result.Count == 0;
            }
        }
    }
}
