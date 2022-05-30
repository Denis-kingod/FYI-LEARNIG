using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using tcc_dbfyi.Context;
using tcc_dbfyi.Interfaces;
using tcc_dbfyi.Repositories;

namespace tcc_dbfyi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // services.Configure<EnvioEmailConfiguracoes>(Configuration.("EnvioEmailConfiguracoes"));

            //services.AddTransient<IEnvioEmailServices, EnvioEmailServices>();

            services
                .AddControllers()
                .AddNewtonsoftJson(options => {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });


            services.AddCors(options =>
            {
                options.AddPolicy("CorPolicy",
                                builder =>
                                {
                                    builder.WithOrigins("http://localhost:3000")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                                });
            });

            services
               .AddAuthentication(options =>
               {
                   options.DefaultAuthenticateScheme = "JwtBearer";
                   options.DefaultChallengeScheme = "JwtBearer";
               })

               .AddJwtBearer("JwtBearer", options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("dbfyi-key-authentication")),
                       ClockSkew = TimeSpan.FromMinutes(90),
                       ValidIssuer = "DBFYI.web.Api",
                       ValidAudience = "DBFYI.web.Api"
                   };
               });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DBFYI.web.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DBFYI.webAPI");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseCors("CorPolicy");

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}