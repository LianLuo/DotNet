using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using ResturantWebApp.Models;
using ResturantWebApp.Repo;

namespace ResturantWebApp
{
    public class Startup
    {
        private readonly string CUST_CORS = "CUST_CORS";
        public Startup(IConfiguration configuration)
        {
            using(var client = new AppDbContext())
            {
                // ensure database has been created.
                client.Database.EnsureCreated();
            }

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // add json config and keep origin property and include case.
            services.AddControllers().AddNewtonsoftJson(opt=>{
                opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            // add Cors
            services.AddCors(opt=>{
                opt.AddPolicy(CUST_CORS,builder=>{
                    builder.WithOrigins(Configuration["ApplicationSettings:AllowHost"])
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            // add auto mapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // add dbContext
            services.AddEntityFrameworkSqlite().AddDbContext<AppDbContext>();

            // inject applicationSettings
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(CUST_CORS);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
