using CognizantChallenge.BusinessLogic.Converters.Implementations;
using CognizantChallenge.BusinessLogic.Converters.Interfaces;
using CognizantChallenge.BusinessLogic.Factories.Implementations;
using CognizantChallenge.BusinessLogic.Factories.Interfaces;
using CognizantChallenge.BusinessLogic.Helpers.Implementations;
using CognizantChallenge.BusinessLogic.Helpers.Interfaces;
using CognizantChallenge.BusinessLogic.Models;
using CognizantChallenge.BusinessLogic.Services.Implementations;
using CognizantChallenge.BusinessLogic.Services.Interfaces;
using CognizantChallenge.Core.Database;
using CognizantChallenge.Core.Database.Entities;
using CognizantChallenge.DAL.Repositories.Implementations;
using CognizantChallenge.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CognizantChallenge
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
            services.AddHttpClient();
            services.AddControllers();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            // Configure database connection
            services.AddDbContext<DataContext>(o => o.UseSqlServer(Configuration.GetConnectionString("ChallengeDb")));

            // Configure DI for application services
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IChallengeService, ChallengeService>();
            services.AddScoped<IResultService, ResultService>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IChallengeRepository, ChallengeRepository>();
            services.AddScoped<IJdoodleService, JdoodleService>();
            services.AddScoped<IConverter<ChallengeDto, Challenge>, ChallengeConverter>();
            services.AddScoped<IJdoodleRequestFactory, JDoodleRequestFactory>();
            services.AddScoped<IChallengeInterpreter, ChallengeInterpreter>();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
