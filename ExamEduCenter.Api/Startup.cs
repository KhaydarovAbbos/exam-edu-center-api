using ExamEduCenter.Api.Extensions;
using ExamEduCenter.Data.Contexts;
using ExamEduCenter.Service.Helpers;
using ExamEduCenter.Service.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ExamEduCenter.Api
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
            services.AddDbContext<EduCenterDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("EduCenter"));
            });

            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExamEduCenter.Api", Version = "v1" });
            });


            services.AddHttpContextAccessor();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddCustomServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExamEduCenter.Api v1"));
            }


            if (app.ApplicationServices.GetService<IHttpContextAccessor>() != null)
            {
                HttpContextHelper.Acessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
