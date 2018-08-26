using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace General.Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// IServiceCollection容器的扩展方法·程序集注入DI
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblyName"></param>
        /// <param name="serviceLifetime"></param>
        /// <returns></returns>
        public static IServiceCollection AssemblyDI(this IServiceCollection services, string assemblyName, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            if (string.IsNullOrEmpty(assemblyName))
                throw new ArgumentNullException($"{nameof(assemblyName)}为空");
            Assembly assemblie = LoadAssemblyByName(assemblyName);
            if (null == assemblie)
                throw new NullReferenceException($"{nameof(assemblyName)}.dll不存在");
            Type[] types = assemblie.GetTypes().Where(o => o.IsClass && !o.IsAbstract && o.Name.EndsWith("Service")).ToArray();

            foreach (var type in types)
            {
                var interfaces = type.GetInterfaces();
                if (interfaces != null && interfaces.Any())
                {
                    var interf = interfaces.FirstOrDefault();
                    switch (serviceLifetime)
                    {
                        case ServiceLifetime.Singleton:
                            services.AddSingleton(interf, type);
                            break;
                        case ServiceLifetime.Scoped:
                            services.AddScoped(interf, type);
                            break;
                        case ServiceLifetime.Transient:
                            services.AddTransient(interf, type);
                            break;
                        default:
                            break;
                    }
                }
            }

            return services;
        }
        /// <summary>
        /// 通过程序集名字加载程序集
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        public static Assembly LoadAssemblyByName(string assemblyName)
        {
            return AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(assemblyName));
        }
    }
}
