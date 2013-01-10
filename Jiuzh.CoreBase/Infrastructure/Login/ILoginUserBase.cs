using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiuzh.CoreBase.Infrastructure
{
    public interface ILoginUserBase
    {
        int Id { get; }
        string LoginName { get; }
        string PassWord { get; }
        string Name { get; }
    }
}
