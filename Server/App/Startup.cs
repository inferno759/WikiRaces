using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Data;
using Data.Entities;
using Library;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;



namespace WikiRacing
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
            string connectionString = Configuration.GetConnectionString("Project2");

            services.AddDbContext<Project2Context>(options =>
            {
                options.UseSqlServer(connectionString);

            });

            services.AddScoped<Library.Interfaces.IRaceRepository, Data.Repositories.RaceRepository>();
            services.AddScoped<Library.Interfaces.IUserRepository, Data.Repositories.UserRepository>();
            services.AddScoped<Library.Interfaces.ILeaderBoardLineRepository, Data.Repositories.LeaderboardLineRepository>();

            services.AddCors(options => options.AddDefaultPolicy(config => config
             .WithOrigins("http://localhost:4200", "https://team4-project2.azurewebsites.net/")
             .AllowAnyMethod()
             .AllowAnyHeader()
             .AllowCredentials()));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WikiRacing", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WikiRacing v1"));
            }

            app.UseStatusCodePages();

            app.UseHttpsRedirection();

            /* change index.html to the mainpage
              
            app.UseRewriter(new RewriteOptions()
                .AddRedirect("^$", "index.html"));
            */
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
