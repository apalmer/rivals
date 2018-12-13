using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using rivals.app.Hubs;
using rivals.domain.Configuration;
using System;
using VueCliMiddleware;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSignalR();

            // In production, the Vue files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot/dist";
            });

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

            services.Configure<DatabaseSettings>(Configuration.GetSection("DocumentDB"));
            services.AddOptions();

            services.AddTransient<persistence.ISpikeRepo, persistence.SpikeRepo>();
            services.AddTransient<persistence.UserSessionRepo>();
            services.AddTransient<logic.Session.UserSessionManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseSpaStaticFiles();
			
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

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:8082/");
                    //spa.UseVueCli(npmScript: "serve", port: 8082);
                }
            });
        }
    }
}
