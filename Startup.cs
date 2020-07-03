using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;


// para uso da autenticação
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace ecommerce
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
            #region Obtendo as configurações do projeto
            AppSettings appSettings = new AppSettings();
            #endregion

            #region Responsavel pela deserializacao do appsettings.json
            //
            var config = new ConfigureFromConfigurationOptions<object>(Configuration.GetSection("AppSettings"));
            config.Configure(appSettings);
            #endregion

            #region Serviço apra Cookie Autorization

            services.AddAuthentication(option => {

                option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddCookie(option =>
            {
                option.Cookie.Name = "CookieAuth";
                option.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Logar/Index");
                option.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Logar/Index");
                option.ExpireTimeSpan = TimeSpan.FromDays(appSettings.CookieTempoVida);
            });

            services.AddAuthorization(option =>
            {
                option.AddPolicy("CookieAuth",
                    new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            #endregion

            services.AddSingleton<AppSettings>(appSettings);
            System.Environment.SetEnvironmentVariable("MYSQLSTRCON", appSettings.StringConexaoMySql);

            


            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Catalogo}/{action=Index}/{id?}");
            });
        }
    }
}
