using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Jiuzh.CoreBase;

using Microsoft.Practices.Unity.InterceptionExtension;
namespace Jiuzh.Infrastructure.EnterpriseLibrary
{
    public class AuthorizeCallback : ICallHandler, IDisposable
    {
        private string _res = null;
        private string _resid;
        public AuthorizeCallback(string resourceId,string resourceName)
        {
            _res = resourceName;
            _resid = resourceId;
        }

        private int order;
        public int Order
        {
            get
            {
                return order;
            }
            set
            {
                order = value;
            }
        }
        public void Dispose()
        {

        }
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get { return true; }
        }


        #region ICallback
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            if (input == null) throw new ArgumentNullException("input");
            if (getNext == null) throw new ArgumentNullException("getNext");
            IMethodReturn result;
            result = getNext()(input, getNext);
            if (_resid != "1")
            {
                AuthorizeException ex = new AuthorizeException();
                result.Exception = ex;

            }
           
            return result;
        }
        #endregion
    }
}
