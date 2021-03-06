﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiuzh.CoreBase.DomainObjects
{
    public interface IStampedEntity
    {
        DateTime CreatedAt
        {
            get;
        }

        DateTime ModifiedAt
        {
            get;
            set;
        }

        int UserId { get; }
    }
}
