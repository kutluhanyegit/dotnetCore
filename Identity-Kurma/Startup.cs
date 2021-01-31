using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using rentid.Context;
using rentid.Entities;

namespace rentid
{
    public class Startup
    {
        public IConfiguration config { get;}
        public Startup(IConfiguration config)
        {
            this.config = config;
        }
        
        
        public void ConfigureServices(IServiceCollection services)
        {

            //EF Core middleware
            services.AddDbContext<appDbContext>( opt => {
                opt.UseSqlServer(config.GetConnectionString("SQL"));
            });
            
            //Identity middleware
            services.AddIdentity<appUser,appRole>().AddEntityFrameworkStores<appDbContext>();
            
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{controller=anasayfa}/{action=index}/{id?}"
                );
            });
        }
    }
}
