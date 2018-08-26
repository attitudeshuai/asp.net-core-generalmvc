using General.Bussiness.ISerivces;
using General.Core.Data;
using General.Domian.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace General.Bussiness.Serivces
{
    public class SysUserService : ISysUserService
    {
        private IRespository<SysUser> sysUserRespository;
        public SysUserService(IRespository<SysUser> _sysUserRespository)
        {
            this.sysUserRespository = _sysUserRespository;
        }
        /// <summary>
        /// 验证登录信息
        /// </summary>
        /// <param name="accout">登录账号</param>
        /// <param name="password">登录密码</param>
        /// <param name="r">登录随机数</param>
        /// <returns></returns>
        public (bool isSign, string msg, SysUser user) validateUser(string accout, string password, string r)
        {
            SysUser user = new SysUser()
            {
                accout = "123456",
                Id = Guid.NewGuid().ToString().ToLower(),
                name = "小帅"
            };
            return (true, "登录成功", user);
        }
    }
}
