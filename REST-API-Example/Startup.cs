using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using REST_API_Example.Models;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace REST_API_Example
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
            services.AddDbContext<ColorContext>(opt => opt.UseInMemoryDatabase("HexLane"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();

            // Check API Key
            app.Use((context, next) =>
            {
                string authHeader = context.Request.Headers["Authorization"];
                string apiKey = System.Environment.GetEnvironmentVariable("KEY");

                if (string.IsNullOrEmpty(authHeader) || !authHeader.Equals(apiKey)) {

                    Dictionary<string, string> responseBody = new Dictionary<string, string>() {
                        { "error", "true" },
                        { "message", "Invalid or missing API key." }
                    };

                    string jsonResponse = JsonConvert.SerializeObject(responseBody);

                    context.Response.StatusCode = 401;
                    context.Response.ContentType = "application/json";
                    
                    return context.Response.WriteAsync(jsonResponse);
                }

                return next();
            });


            app.UseMvc();
        }
    }
}