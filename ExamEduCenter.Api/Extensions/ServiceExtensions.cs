using ExamEduCenter.Data.IRepositories;
using ExamEduCenter.Data.Repositories;
using ExamEduCenter.Service.Interfaces;
using ExamEduCenter.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExamEduCenter.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection service)
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<ICourseService, CourseService>();
            service.AddScoped<ICourseTypeService, CourseTypeService>();
        }
    }
}
