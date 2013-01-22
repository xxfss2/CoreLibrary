using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiuzh.CoreBase.DomainObjects
{
    public interface IContactContainer
    {
        string ContactName { get; }
        char ContactSex { get; }
        DateTime BirthDate { get; }

    }
}
