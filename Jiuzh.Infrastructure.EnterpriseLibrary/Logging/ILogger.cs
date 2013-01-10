using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiuzh.Infrastructure.EnterpriseLibrary
{
    using Microsoft.Practices.EnterpriseLibrary.Logging;
    public interface ILogger
    {
        void Write(LogEntry entry);
    }
}
