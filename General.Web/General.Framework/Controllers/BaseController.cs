
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text; 

namespace General.Framework.Controllers
{
    public abstract class BaseController: Controller
    {
        public BaseController()
        {
            Result = new AjaxResult();
        }
        /// <summary>
        /// ajax的响应数据
        /// </summary>
        public AjaxResult Result { get; }
    }
}
