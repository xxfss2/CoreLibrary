using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiuzh.CoreBase
{
    public class AuthorizeException : Exception
    {
        public AuthorizeException(String str) : base(str) { }
        public AuthorizeException() : base() { }
    }
}
