using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace TheWall
{
    public class Startup
    {
        // need to add constructor function to Startup that runs code to include the new appsettings.json file when program builds
        public Startup(IConfiguration configuration, IHostingEnvironment env) // IHostingEnvironment provides information about the web hosting environment an application is running in.
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath) //Sets the FileProvider for file-based providers to a PhysicalFileProvider with the base path.
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true) // Adds the JSON configuration provider at path to builder 
            .AddEnvironmentVariables(); // Adds a Microsoft.Extensions.Configuration.IConfigurationProvider that reads configuration values from environment variables.
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // ADD DBInfo object as a service so we can access the object in other parts of our code outside the Startup.cs file
            services.Configure<MySqlOptions>(Configuration.GetSection("DBInfo"));
            services.AddSession();
            services.AddScoped<DbConnector>(); // add DbConnector as a service
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
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
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}