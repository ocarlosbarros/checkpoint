using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CheckPoint
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            services.AddSession(
                options => 
                {
                    options.Cookie.Name="CheckPoint.Session";
                    options.IdleTimeout= TimeSpan.FromSeconds(10);
                    options.Cookie.IsEssential = true;
                } 
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseStaticFiles();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseEndpoints(endpoints => endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}"));
        }
    }
}
