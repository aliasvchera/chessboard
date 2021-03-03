using System.Threading.Tasks;
using ChessBoard.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ChessBoard.Infrastructure;
using PaulMiami.AspNetCore.Mvc.Recaptcha;

namespace ChessBoard
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:ChessBoardData:ConnectionString"]));
            services.AddDbContext<ApplicationIdentityContext>(options => options.UseSqlServer(Configuration["Data:ChessBoardIdentity:ConnectionString"]));
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;

            }).AddEntityFrameworkStores<ApplicationIdentityContext>();
            services.AddTransient<IChessBoardRepository, EFChessBoardRepository>();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddRecaptcha(new RecaptchaOptions
            {
                SiteKey = Configuration["Recaptcha:SiteKey"],
                SecretKey = Configuration["Recaptcha:SecretKey"]
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    //template: "{controller=Transition}/{action=Map}/{id?}");
                    //template: "{controller=Military}/{action=TestMap}/{id?}");
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            Log.LoggerFactory = loggerFactory;
            /*
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddDebug();
            });
            ILogger<Startup> logger = loggerFactory.CreateLogger<Startup>();
            app.Run(async (context) =>
            {
                logger.LogInformation($"Processing request {context.Request.Path}");

                await context.Response.WriteAsync("MAGISTER MILITVM is started");
            });*/
            /*
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
            */
        }
    }
}
