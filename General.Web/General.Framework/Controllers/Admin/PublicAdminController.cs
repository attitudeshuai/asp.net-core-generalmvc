using General.Core;
using General.Domian.Entity;
using General.Framework.Filters;
using General.Framework.Infraustrasture;
using System;
using System.Collections.Generic;
using System.Text;

namespace General.Framework.Controllers.Admin
{
    /// <summary>
    /// 判断登录控制器继承
    /// </summary>
    [AdminAuthFilter]
    public class PublicAdminController : BaseController
    {
        public PublicAdminController()
        {
            WorkContext = EngineContext.current.Resolve<IWorkContext>();
        }

        public IWorkContext WorkContext { get; }
    }
}
