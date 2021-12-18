using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using project_intro.Contracts;
using project_intro.Filters;
using project_intro.Models.Config;
using project_intro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_intro
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(x => x.AddPolicy("Leumit", x => x.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader()));
            services.AddAutoMapper(typeof(Startup));
            services.Configure<RedisConfiguration>(Configuration.GetSection("Redis"));
        
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = false;
            });

            services.AddScoped<ICourseApiExceptionFilter, CourseApiExceptionFilter>();
            services.AddSingleton<IUsersService, ShimonUsersService>();
            services.AddSingleton<INotifier, ConsoleNotifier>();
            services.AddSingleton<IProductService, ProductMockService>();

            services.AddControllers(config=> {
                config.Filters.AddService(typeof(ICourseApiExceptionFilter));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "project_intro", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("Leumit");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "project_intro v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // web api
            });
        }
    }
}




//app.UseStaticFiles();
//app.Use(async (context, next) => {
//    await context.Response.WriteAsync(" M1 Start ");
//    await next();
//    await context.Response.WriteAsync(" M1 End ");

//});

//app.Use(async (context, next) => {
//    await context.Response.WriteAsync(" M2 Start ");
//    await next();
//    await context.Response.WriteAsync(" M2 End");
//});

//app.Run(async (context) => {
//    await context.Response.WriteAsync("Hello");
//});

