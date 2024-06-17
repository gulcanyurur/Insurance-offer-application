using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Business.Abstract;
using Business.Concrete;
using Microsoft.EntityFrameworkCore;

namespace WebAPI
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
            services.AddControllers();

            services.AddScoped<IPolicyDal, EfPolicyDal>();
            services.AddScoped<IPolicyService, PolicyManager>();

            services.AddScoped<IPolicyCoverageDal, EfPolicyCoverageDal>();
            services.AddScoped<IPolicyCoverageService, PolicyCoverageManager>();

            services.AddScoped<ICoverageService, CoverageManager>();
            services.AddScoped<ICoverageDal, EfCoverageDal>();

            services.AddScoped<ITravelDetailDal, EfTravelDetailDal>();
            services.AddScoped<ITravelDetailService, TravelDetailManager>();

            services.AddScoped<IPaymentDal, EfPaymentDal>();
            services.AddScoped<IPaymentService, PaymentManager>();

            services.AddScoped<IInsuredDal, EfInsuredDal>();
            services.AddScoped<IInsuredService, InsuredManager>();

            services.AddScoped<IInsurerDal, EfInsurerDal>();
            services.AddScoped<IInsurerService, InsurerManager>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Eureko API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3009")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Eureko API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseCors("AllowSpecificOrigin");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}



