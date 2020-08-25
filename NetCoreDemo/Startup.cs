using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCoreDemo.Services;

namespace NetCoreDemo
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            this._configuration = configuration;
            //var netCoreDemo = this._configuration["NetCoreDemo:BoldDepartmentEmployeeCountThreshold"];
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //注册服务
            services.AddControllersWithViews();
            services.AddSingleton<IClock, ChinaClock>();
            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();

            services.Configure<NetCoreDemoOptions>(_configuration.GetSection("NetCoreDemo"));
            //test
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //管道
            //处理http请求,插入中间件
            //1.auth 身份认证
            //2.mvc,grpc,node js.....
            //3.static files(html,js,css)
            //4.路由
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //使用静态文件
            app.UseStaticFiles();

            //http请求转换成https请求
            app.UseHttpsRedirection();

            app.UseAuthentication();

            //路由中间件
            app.UseRouting();
            //端点中间件
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                //use MVC
                app.UseEndpoints(endpoints =>
                {
                    //路由表
                    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Department}/{action=Index}/{id?}");
                });
            });
        }
    }
}
