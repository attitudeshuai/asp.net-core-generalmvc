using General.Framework.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace General.Framework.Controllers.Admin
{
    /// <summary>
    /// 需要权限控制器继承
    /// </summary>
    [PermissionActionFilter]
    public class AdminPermissionController : BaseController
    {
    }
}
