using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiuzh.Infrastructure.EnterpriseLibrary
{
    using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
    public class WebLogTraceTextFormatterData:TextFormatterData
    {

        public WebLogTraceTextFormatterData() { }

        public WebLogTraceTextFormatterData(string templateData):base(templateData){}

        public WebLogTraceTextFormatterData(string name, string templateData)
            : base(name, templateData)
        {
            
        }

       // public WebLogTraceTextFormatterData(string name, Type formatterType, string templateData) : base(name, templateData) { }

    }
}
