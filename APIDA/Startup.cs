using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using APIPCHY.Models;
using APIPCHY.Services;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;

namespace APIPCHY
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
            
            services.AddSwaggerGen();
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            //services.AddAuthentication(opt =>
            //{
            //    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        //ValidIssuer = "http://localhost:5001",
            //        //ValidAudience = "http://localhost:5001",
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
            //    };
            //});

            

            services.AddDirectoryBrowser();
            //services.AddDbContext<doan5Context>(options =>
           // options.UseSqlServer(Configuration.GetConnectionString("connection")));
           

            //services.Configure<FormOptions>(o =>
            //{
            //    o.ValueLengthLimit = int.MaxValue;
            //    o.MultipartBodyLengthLimit = int.MaxValue;
            //    o.MemoryBufferThreshold = int.MaxValue;
            //});

            services.AddControllers();
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
            //        Configuration["jwt:Issuer"],
            //        Configuration["jwt:Audience"],
            //    );

           

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
                AddJwtBearer(o =>
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = Configuration["Jwt:Issuer"],
                ValidAudience = Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true
            });


            //services
                //.AddJwtBearerConfiguration(_configuration["Jwt:Issuer"],
                //                      _configuration["Jwt:Audience"]);

            services.AddScoped<IFileService, FileService>();
        }

        // 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIPCHY v1"));
            }
            app.UseStaticFiles();

            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "Resources")),
                RequestPath = "/Resources",
                EnableDirectoryBrowsing = false
            });
            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

//             builder.Services.AddAuthentication();
// builder.Services.AddAuthorization();
// builder.Services.ConfigureIdentity();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseRouting();

           
           






        }
    }
}
