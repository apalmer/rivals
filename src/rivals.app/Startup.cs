﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rivals.app.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using rivals.app.Hubs;
using rivals.persistence;
using rivals.domain.Configuration;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace rivals.app
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
            
            services.AddSingleton<DocumentClient>(new DocumentClient(
                new Uri(Configuration.GetValue<String>("DocumentDB:EndpointURL")),
                Configuration.GetValue<String>("DocumentDB:PassKey")
                )
            );

            services.AddIdentityWithDocumentDBStores(
                dbOptions =>
                {
                    dbOptions.DocumentUrl = Configuration.GetValue<String>("DocumentDB:EndpointURL");
                    dbOptions.DocumentKey = Configuration.GetValue<String>("DocumentDB:PassKey");
                    dbOptions.DatabaseId = Configuration.GetValue<String>("DocumentDB:DatabaseID");
                    dbOptions.CollectionId = Configuration.GetValue<String>("DocumentDB:CollectionID");
                }
            );
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSignalR();

            services.Configure<DatabaseSettings>(Configuration.GetSection("DocumentDB"));
            services.AddOptions();

            services.AddTransient<ISpikeRepo, SpikeRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chatHub");
                routes.MapHub<WorldHub>("/worldHub");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
