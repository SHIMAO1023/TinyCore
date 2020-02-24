using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyCore.Web
{
    public static class ServiceExtension
    {
        /// <summary>
        /// jwt
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = "http://localhost:5000",
                    ValidAudience = "http://localhost:5000",

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("abc123!@#11111111111111"))

                    //todo hardcode => appsettings.json
                };
            });
        }

        /// <summary>
        /// swagger
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "V1",
                    Title = "TinyCore API DOC",
                    Description = "TinyCore HTTP API V1"
                });
                // include document file
                opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{typeof(Startup).Assembly.GetName().Name}.xml"), true);



                // Add security definitions
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "Please enter into field the word 'Bearer' followed by a space and the JWT value",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference()
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        }, Array.Empty<string>()
                    }
                });

            });
        }
    }
}
