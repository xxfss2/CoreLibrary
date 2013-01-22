using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiuzh.CoreBase
{
    public class DataAccessException : Exception
    {
        public DataAccessException() : base() { }

        public DataAccessException(string message) : base(message) { }

        
    }
}
