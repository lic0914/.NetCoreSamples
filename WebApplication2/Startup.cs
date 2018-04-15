using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace ConfigbinderSample
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            /* 模拟Asp.Net Mvc 的 global.cs 的Application事件 */
            applicationLifetime.ApplicationStarted.Register(() =>
            {
                Console.WriteLine("Application Started");
            });
            applicationLifetime.ApplicationStopping.Register(() =>
            {
                Console.WriteLine("Application Stopping");
            });
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                Console.WriteLine("Application Stopped");
            });
            app.Run(async (context) =>
            {
                var p = new person();
                Configuration.Bind(p);//使用 Bind() 方法绑定json
                for (int i = 0; i < 3; i++)
                {
                    await context.Response.WriteAsync(p.Hobby[i]);//子元素是 config["hobby:0"] ,config["hobby:0:a"]
                }
                await context.Response.WriteAsync("ok");
                
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
