using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace General.Domian.Param
{
    /// <summary>
    /// admin用户登录模型
    /// </summary>
    public class Param_UserLogin
    {
        /// <summary>
        /// 登录账号
        /// </summary>
        [Required]
        public string accout { get; set; } 
        /// <summary>
        /// 登录密码
        /// </summary>
        [Required]
        public string password { get; set; }
    }
}
