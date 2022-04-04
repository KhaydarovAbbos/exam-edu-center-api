using ExamEduCenter.Domain.Commons;
using ExamEduCenter.Domain.Configuration;
using ExamEduCenter.Domain.Entities.Courses;
using ExamEduCenter.Service.DTOs.Courses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExamEduCenter.Service.Interfaces
{
    public interface ICourseService
    {
        Task<BaseResponse<Course>> CreateAsync(CourseForCreationDto courseDto);

        Task<BaseResponse<Course>> UpdateAsync(CourseForUpdatingDto courseDto);

        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Course, bool>> expression);

        Task<BaseResponse<Course>> GetAsync(Expression<Func<Course, bool>> expression);

        Task<BaseResponse<IEnumerable<Course>>> GetAllAsync(PaginationParams @params, Expression<Func<Course, bool>> expression = null);

        Task<BaseResponse<Course>> SetImageAsync(long courseId, IFormFile file);

        Task<string> GetImageAsync(long courseId);

        Task<BaseResponse<Course>> UpdateCoureAuthor(long courseId, string Author);
    }
}
