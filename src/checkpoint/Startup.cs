﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace pontoDigital
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Adicionando um service ao projeto - neste caso o service MVC
            services.AddMvc();
            
            //Adicionando Session a aplicação e setando algumas configurações em options
            services.AddSession(
                options => 
                {
                    options.Cookie.Name="Ponto_Digital.Session";
                    options.IdleTimeout= TimeSpan.FromSeconds(10);
                    options.Cookie.IsEssential = true;
                } 
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseStaticFiles();//Habilitando para que a pasta wwwroot seja pública a aplicaçao
            app.UseHttpsRedirection();//Habilitando redirection action
            app.UseCookiePolicy();//Habilidando  Politica de Cookie
            app.UseSession();//Habilitando Session

            //Configurando a utilizaçao do MVC para configurar as rotas da aplicação
            app.UseMvc(routes =>
            {

                routes.MapRoute(
                    //Definindo o nome padrão da rota
                    name: "default",
                    //Definindo o template da rota padrao da aplicação
                    template: "{controller=Home}/{action=Index}");
            });
        }
    }
}
