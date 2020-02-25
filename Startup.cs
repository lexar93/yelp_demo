using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Allegro_Graph_CSharp_Client.AGClient.OpenRDF.Model;
using Allegro_Graph_CSharp_Client.AGClient.OpenRDF.Query;
using Allegro_Graph_CSharp_Client.AGClient.OpenRDF.RepositoryUtil;
using Allegro_Graph_CSharp_Client.AGClient.OpenRDF.Sail;
using KnowledgeGraph.AGClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KnowledgeGraph
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
            services.AddRazorPages();

            services.AddSingleton<IAllegroGraphHttpClient>(new AllegroGraphHttpClient(host: Configuration.GetValue<string>("AllegroGraphHttpClient:Host"),
                port: Configuration.GetValue<int>("AllegroGraphHttpClient:Port"),
                username: Configuration.GetValue<string>("AllegroGraphHttpClient:Username"),
                password: Configuration.GetValue<string>("AllegroGraphHttpClient:Password"),
                catalog: Configuration.GetValue<string>("AllegroGraphHttpClient:Catalog"),
                repository: Configuration.GetValue<string>("AllegroGraphHttpClient:Repository")
                ));
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
