using General.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace General.Web
{
    /// <summary>
    /// 构建实例的引擎实现类
    /// </summary>
    public class GeneralEngine : IEngine
    {
        private ServiceProvider serviceProvider;
        public GeneralEngine(ServiceProvider _serviceProvider)
        {
            serviceProvider = _serviceProvider;
        }
        public T Resolve<T>() where T : class
        {
            var a= serviceProvider.GetService<T>();
            return a;
        }
    }
}
