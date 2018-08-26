using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace General.Framework.Filters
{
    /// <summary>
    /// 登录状态过滤器
    /// </summary>
    public class AdminAuthFilterAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        { 

        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        { 
        }
    }
}
