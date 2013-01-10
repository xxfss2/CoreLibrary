using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Jiuzh.CoreBase.Infrastructure
{
    public abstract class LoginUserBase
    {
        public int Id
        {
            get { return Convert.ToInt32(HttpContext.Current.Session[LoginBase .SUSERID ]); }
        }
        public string LoginName
        {
            get { return HttpContext.Current.Session[LoginBase . SLOGINNAME].ToString(); }
        }
        public string PassWord
        {
            get { return HttpContext.Current.Session[LoginBase . SPASWORD].ToString(); }
        }
        public string Name
        {
            get { return HttpContext.Current.Session[LoginBase. SUSERNAME].ToString(); }
        }
    }
}
