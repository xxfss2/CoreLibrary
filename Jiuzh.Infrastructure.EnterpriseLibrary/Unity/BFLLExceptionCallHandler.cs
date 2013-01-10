using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Jiuzh.CoreBase;
namespace Jiuzh.Infrastructure.EnterpriseLibrary
{
    public class BFLLExceptionCallback : ICallHandler,IDisposable
    {
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
            if (result.Exception != null)
            {
                try
                {
                    Exception ex = result.Exception;
                    bool rethrow = true;

                    rethrow = ExceptionPolicy.HandleException(result.Exception, Contants.EXCEPTIONPOLICY_BFLLEXCEPION_POLICYS);

                    if (((ex is ArgumentException) == false) && ((ex is AuthorizeException) == false))
                    {
                        BFLLException bex = new BFLLException("BFLL Exception", ex);
                        result.Exception = bex;
                    }
                    if (!rethrow)
                    {
                        // Exception is being swallowed
                        result.ReturnValue = null;
                        result.Exception = null;

                        if (input.MethodBase.MemberType == MemberTypes.Method)
                        {
                            MethodInfo method = (MethodInfo)input.MethodBase;
                            if (method.ReturnType != typeof(void))
                            {
                                result.Exception =
                                    new InvalidOperationException();
                            }
                        }
                    }
                    
                    // Otherwise the original exception will be returned to the previous handler
                }
                catch (Exception ex)
                {
                    // New exception was returned
                    result.Exception = ex;
                }
            }
            return result;
        }
        #endregion
    }
}
