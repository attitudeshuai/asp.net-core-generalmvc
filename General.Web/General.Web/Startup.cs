using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using General.Core;
using General.Core.Data;
using General.Core.Extensions;
using General.Domian;
using General.Framework;
using General.Framework.Infraustrasture;
using General.Framework.Infraustrasture.Admin;
using General.Framework.Security;
using General.Framework.Security.Admin;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace General.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddMvc();
            //添加数据库连接到dbcontext上下文池
            services.AddDbContextPool<_DbContext>(o =>
            {
                o.UseSqlServer(Configuration.GetConnectionString("DefualtConnection"));
            });
            services.AddAuthentication(CookieAdminAuthInfo.AuthenticationScheme).AddCookie(CookieAdminAuthInfo.AuthenticationScheme, o =>
            {
                o.LoginPath = "/admin/login";
            }); 
            services.AddScoped<IAdminAuthService, AdminAuthService>();
            services.AddScoped<IWorkContext, WorkContext>();
            
            //程序集注入DI
            services.AssemblyDI("General.Bussiness");
            //泛型注入到DI
            services.AddScoped(typeof(IRespository<>), typeof(EfRepository<>));
            //注入工作单元
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            //注册引擎
            EngineContext.Initialize(new GeneralEngine(services.BuildServiceProvider()));
            //注入asp.netcore.HttpContext
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();//启动授权
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=login}/{action=Index}/{id?}"
                );
            });
        }
    }
}
