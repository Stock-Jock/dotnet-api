using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SJApi.DataService.Interfaces;
using SJApi.DataService.Services;
using SJApi.ObjectModel.Models;

namespace SJApi.WebApi
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

            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddScoped<IHttpClient, TypedHttpClient>();
            services.AddScoped<IIEXService, IEXService>();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SJApi.WebApi", Version = "v1" });
            });
            services.AddHttpClient("IEX", client => {
                client.BaseAddress = new Uri("https://cloud.iexapis.com");
                client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory");
            });
            services.AddScoped<ServiceConfig>(m => {
                // var pk = Configuration.GetConnectionString("pk");
                return new ServiceConfig
                {
                    IEXUrl = "stable/ref-data/symbols?token=pk_47017819d55f4fa387ee42458b6a4dd5",
                    IEXClient = "IEX"
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SJApi.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
