using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using Jiuzh.CoreBase.DomainObjects;

namespace Jiuzh.CoreBase.Infrastructure
{
    public abstract  class LoginBase : ILoginBase
    {

        internal const string SLOGINNAME = "loginName";
        internal const string SPASWORD = "password";
        internal const string SUSERID = "userid";
        internal const string SUSERNAME = "userName";


        public bool IsLogin()
        {
            return HttpContext.Current.Session[SUSERID] != null ? true : false;
        }

        protected virtual void LoggedinInit(IUserBase loginuser)
        {
            IUserBase user = loginuser;
            HttpContext.Current.Session[SLOGINNAME] = user.LoginName;
            HttpContext.Current.Session[SPASWORD] = user.PassWord;
            HttpContext.Current.Session[SUSERID] = user.Id;
            HttpContext.Current.Session[SUSERNAME] = user.Name;
        }

    }
}
