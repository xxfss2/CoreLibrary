using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Unity.InterceptionExtension;
using Jiuzh.CoreBase.Infrastructure;
namespace Jiuzh.Infrastructure.EnterpriseLibrary
{
    public class LogFunctionCallHandler : ICallHandler, IDisposable
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

            IParameterCollection coll = input.Inputs;
            string strParaName, strParaValue;
            int n = coll.Count;
            string strMessage = input.MethodBase.Name + "[";
            //需要改进,如果参数为数组时,不能准确的表达数值,只能显示TestArray[arr=System.Int32[];]
            for (int i = 0; i < n; i++)
            {
                strParaValue = coll[i].ToString();
                strParaName = coll.ParameterName(i).ToString();
                strMessage = strMessage + strParaName + "=" + strParaValue + ";";
            }
            strMessage = strMessage + "]";
            Log.Info(strMessage);


            var result = getNext()(input, getNext);

            return result;
        }
        #endregion

    

    }
}
