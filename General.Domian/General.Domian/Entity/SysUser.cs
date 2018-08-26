using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace General.Domian.Entity
{
    /// <summary>
    /// 系统用户
    /// </summary>
    [Table("SysUsers")]
    public class SysUser
    {
        public string Id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string accout { get; set; } 
        public string salt { get; set; } 
    }
}
