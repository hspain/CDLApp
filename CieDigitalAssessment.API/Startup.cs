using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Microsoft.EntityFrameworkCore;
using CieDigitalAssessment.API.Models;
using CieDigitalAssessment.API;
using CieDigitalAssessment.DAL;

using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CieDigitalAssessment
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
            services.AddMvc();
            services.AddDbContext<CieDigitalAssessment.API.CDLAppContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CDLApp")));

            // configure DI for application services
            services.AddScoped<IApplicationRepository<Movie>, ApplicationRepository<Movie>>();
            services.AddScoped<IApplicationRepository<User>, ApplicationRepository<User>>();
            services.AddScoped<IApplicationRepository<Customer>, ApplicationRepository<Customer>>();
            services.AddScoped<IApplicationRepository<Location>, ApplicationRepository<Location>>();
            services.AddScoped<IApplicationRepository<MovieCopy>, ApplicationRepository<MovieCopy>>();
            services.AddScoped<IApplicationRepository<RentalBox>, ApplicationRepository<RentalBox>>();
            services.AddScoped<IApplicationRepository<Transaction>, ApplicationRepository<Transaction>>();
            services.AddScoped<IApplicationRepository<TransactionMovieCopy>, ApplicationRepository<TransactionMovieCopy>>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "CDL API", Version = "v1" });
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("superSuperSecretKey")),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CDL API V1");
            });

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
