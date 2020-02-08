using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCore.Entity
{
    public class User : EntityBase
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
