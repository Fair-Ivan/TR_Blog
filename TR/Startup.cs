using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore;
using TR.Models;
using TR.ILogicHandler;
using TR.LogicHandler;
using TR.IRepositories;
using TR.Repositories;
using TR.Unit;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace TR
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                  .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                  {
                      o.LoginPath = new PathString("/Login");
                      o.AccessDeniedPath = new PathString("/Login");
                      o.ExpireTimeSpan = TimeSpan.FromHours(0.5);
                  });

            services.AddMvc().AddJsonOptions(option =>
            {
                option.SerializerSettings.DateFormatString = "yyyy/MM/dd HH:mm:ss";
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "The Blog of Ivan", Version = "v1" });
                var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.DocumentFilter<HiddenFilter>();
            });

            services.AddTransient<IUserLogicHandler, UserLogicHandler>();
            services.AddTransient<IUserRepository, UserRepositoy>();
            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<IBlogLogicHandler, BlogLogicHandler>();
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            //配置session
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(2);
            });

            services.AddDbContext<TrContext>(
                options =>
                options.UseMySql(Configuration.GetConnectionString("Blogs"))
                );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Blog}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog API");
            });
        }
    }
}
