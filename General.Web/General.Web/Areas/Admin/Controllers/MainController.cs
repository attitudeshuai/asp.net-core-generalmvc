using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using General.Framework.Controllers.Admin;
using Microsoft.AspNetCore.Mvc;

namespace General.Web.Areas.Admin.Controllers
{  
    [Area("admin")]
    public class MainController : PublicAdminController
    {
        public IActionResult Index()
        {
            var user = WorkContext.currentUser;
            return View();
        }
    }
}