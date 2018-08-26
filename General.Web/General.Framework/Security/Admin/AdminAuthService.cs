using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using General.Domian.Dto;
using General.Domian.Entity;
using General.Framework.Security.Admin;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace General.Framework.Security
{
    public class AdminAuthService : IAdminAuthService
    {
        private IHttpContextAccessor httpContextAccessor; 
        public AdminAuthService(IHttpContextAccessor _httpContextAccessor)
        {
            this.httpContextAccessor = _httpContextAccessor;
        }
        /// <summary>
        /// 获取用户信息
        /// （从缓存中取出来）
        /// </summary>
        /// <returns></returns>
        public SessionUser GetCurrentUser()
        {
            var result = httpContextAccessor.HttpContext.AuthenticateAsync(CookieAdminAuthInfo.AuthenticationScheme).Result;
            var token = result.Principal.FindFirstValue(ClaimTypes.Sid);
            var name = result.Principal.FindFirstValue(ClaimTypes.Name);
            return new SessionUser() { Id = token, name = name };
        }
        /// <summary>
        /// 保存登录信息
        /// </summary>
        /// <param name="token"></param>
        /// <param name="name"></param>
        public void SignIn(string token, string name)
        {
            ClaimsIdentity identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ClaimTypes.Sid, token));
            identity.AddClaim(new Claim(ClaimTypes.Name, name));
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            httpContextAccessor.HttpContext.SignInAsync(CookieAdminAuthInfo.AuthenticationScheme, principal); 
        }
    }
}
