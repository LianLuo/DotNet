using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularForDotnetCore.Components;
using AngularForDotnetCore.Models;
using AngularForDotnetCore.Repo;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;

namespace AngularForDotnetCore
{
    public class Startup
    {
        private readonly string MyCors = "ANY";
        public Startup(IConfiguration configuration)
        {
            using (var client = new ApiDbContext())
            {
                client.Database.EnsureCreated();
            }
            using (var client = new ApplicationUserContext())
            {
                client.Database.EnsureCreated();
            }
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //Inject AppSettings;

            services.Configure<AppSettings>(Configuration.GetSection("ApplicationSetttings"));

            services.AddControllers().AddNewtonsoftJson(opt =>
            {
                // solute object to json, property will be lowercase first letter.
                opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });


            #region add autoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); 
            #endregion

            #region add db context
            services.AddEntityFrameworkSqlite().AddDbContext<ApiDbContext>();
            services.AddEntityFrameworkSqlite().AddDbContext<ApplicationUserContext>();
            #endregion

            #region add CORS

            services.AddCors(opt =>
            {
                opt.AddPolicy(MyCors, builder =>
                {
                    builder.WithOrigins(Configuration["ApplicationSetttings:AllowHost"])
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            }); 
            #endregion

            services.AddScoped<BankAccountComponent>();
            services.AddScoped<BankComponent>();
            services.AddScoped<EmployeeComponent>();
            services.AddScoped<PaymentDetailComponent>();
            services.AddScoped<ApplicationUserComponent>();
            services.AddAuthentication(x =>
            {

                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["ApplicationSetttings:JWT_Security"].ToString())),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
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
            app.UseCors(MyCors);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
