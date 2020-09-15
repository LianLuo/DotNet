using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularForDotnetCore.Components;
using AngularForDotnetCore.Repo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AngularForDotnetCore
{
    public class Startup
    {
        private readonly string MyCors = "ANY";
        public Startup(IConfiguration configuration)
        {
            using(var client = new ApiDbContext())
            {
                client.Database.EnsureCreated();
            }
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddEntityFrameworkSqlite().AddDbContext<ApiDbContext>();
            services.AddCors(opt=>{
                opt.AddPolicy(MyCors, builder=>{
                    builder.WithOrigins("http://localhost:4200")                    
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
            services.AddScoped<BankAccountComponent>();
            services.AddScoped<BankComponent>();
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

            //app.UseAuthorization();
            app.UseCors(MyCors);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
