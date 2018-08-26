using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using General.Bussiness.ISerivces;
using General.Domian.Entity;
using General.Domian.Param;
using General.Framework.Controllers.Admin;
using General.Framework.Security;
using Microsoft.AspNetCore.Mvc;

namespace General.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class LoginController : PublicAdminController
    {
        private ISysUserService sysUserService;
        private IAdminAuthService adminAuthService;
        public LoginController(ISysUserService _sysUserService,
            IAdminAuthService _adminAuthService)
        {
            sysUserService = _sysUserService;
            adminAuthService = _adminAuthService;
        }
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(Param_UserLogin param)
        {
            if (!ModelState.IsValid)
            {
                Result.message = "账号或者密码输入有误";
                return Json(Result);
            }
            var data = sysUserService.validateUser(param.accout, param.password, "");
            Result.status = data.isSign;
            Result.message = data.msg;

            if (data.isSign)
            {//保存登录状态
                adminAuthService.SignIn("11111111", data.user.name);
            } 
            return Json(Result);
        }
    }
}