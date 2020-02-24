using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCore.Service.dto
{
    /// <summary>
    /// 登陆传输实体
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
