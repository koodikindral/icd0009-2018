﻿using System.Collections.Generic;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Add DB context
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<AppDbContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("Database")))
                .BuildServiceProvider();
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Schemes = new List<SwaggerSchema> {SwaggerSchema.Https};
                    document.Info.Version = "v1";
                    document.Info.Title = "Sportsbook API";
                    document.Info.Description = "ASP.NET Core web API for sports";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new SwaggerContact
                    {
                        Name = "Gert Vesterberg",
                        Email = string.Empty,
                        Url = "https://koodikindral.com"
                    };
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile("secrets/appsettings.secrets.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UsePathBase("/sports");
            app.UseSwagger();
            app.UseSwaggerUi3(s => { s.DocumentPath = "/swagger/v1/swagger.json"; });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}