using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiuzh.CoreBase.DomainObjects
{
    /// <summary>
    /// 用户信息核心接口
    /// </summary>
    public interface IUserBase
    {
        int Id { get; }
        string Name { get; set; }
        string LoginName { get; set; }
        string PassWord { get; set; }
    }
}
