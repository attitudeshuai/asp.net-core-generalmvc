using General.Domian.Dto;
using General.Domian.Entity;
using General.Framework.Infraustrasture;
using General.Framework.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace General.Framework.Infraustrasture.Admin
{
    /// <summary>
    /// 目前工作上下文
    /// </summary>
    public class WorkContext : IWorkContext
    {
        private IAdminAuthService authenticationService;

        public WorkContext(IAdminAuthService _authenticationService)
        {
            authenticationService = _authenticationService;
        }
        /// <summary>
        /// 获取当前用户上下文
        /// </summary>
        public SessionUser currentUser
        {
            get
            {
                return authenticationService.GetCurrentUser();
            }
        }
    }
}
