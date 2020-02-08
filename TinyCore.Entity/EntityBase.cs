using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCore.Entity
{
    public abstract class EntityBase
    {
        long Id { get; set; }

        DateTime CreateTime { get; set; }

        DateTime UpdateTime { get; set; }

        bool IsActive { get; set; }
    }
}
