using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiuzh.Infrastructure.EnterpriseLibrary
{
    public interface IExceptionPolicy
    {
        bool HandleException(Exception exceptionToHandle, string policyName, out Exception exceptionToThrow);
    }
}
