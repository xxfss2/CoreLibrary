using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jiuzh.CoreBase
{
    public static class UIHelp
    {
        public static object Bind<IView>(this Page page, Func<IView, object> func)
        {
            return func((IView)page.GetDataItem());
        }

        public static object Bind<IView>(this RepeaterItem item, Func<IView, object> func)
        {
            return func((IView)item.DataItem);
        }
    }
}
