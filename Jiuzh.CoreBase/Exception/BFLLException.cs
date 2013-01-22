using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiuzh.CoreBase
{
    public class BFLLException : Exception
    {
        public BFLLException(String str) : base(str) { }
        public BFLLException() : base() { }

        
        public BFLLException(String str, Exception innerException) : base(str, innerException) { }

    }
}
