using General.Domian.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace General.Bussiness.ISerivces
{
    public interface ISysUserService
    {
        /// <summary>
        /// 验证登录信息
        /// </summary>
        /// <param name="accout">登录账号</param>
        /// <param name="password">登录密码</param>
        /// <param name="r">登录随机数</param>
        /// <returns></returns>
        (bool isSign, string msg, SysUser user) validateUser(string accout, string password, string r);
    }
}
