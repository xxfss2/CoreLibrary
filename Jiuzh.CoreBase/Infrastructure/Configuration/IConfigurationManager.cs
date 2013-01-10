using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiuzh.CoreBase.Infrastructure
{
    using System.Collections.Specialized;
    public interface IConfigurationManager
    {
        NameValueCollection AppSettings { get; }
        string GetConnectionString(string name);
        string GetProviderName(string name);
        T GetSection<T>(string sectionName);
    }
}
