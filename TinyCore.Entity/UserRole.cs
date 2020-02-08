using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCore.Entity
{
    public class UserRole : EntityBase
    {
        long UserId { get; set; }

        long RoleId { get; set; }
    }
}
