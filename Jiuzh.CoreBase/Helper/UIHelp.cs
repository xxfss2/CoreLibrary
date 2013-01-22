using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Jiuzh.CoreBase
{
    public static class UIHelp
    {
        public static object Bind<IView>(this Page page, Func<IView, object> func)
        {
            return func((IView)page.GetDataItem());
        }
    }
}
