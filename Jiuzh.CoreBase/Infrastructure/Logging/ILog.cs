using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiuzh.CoreBase.Infrastructure
{
    public interface ILog
    {
        void Info(string message);

        void Warning(string message);

        void Exception(Exception exception);

        void Error(string message);

       
    }
}
