using ExamEduCenter.Domain.Commons;
using ExamEduCenter.Domain.Configuration;
using ExamEduCenter.Domain.Entities.Courses;
using ExamEduCenter.Service.DTOs.Courses;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExamEduCenter.Service.Interfaces
{
    public interface ICourseTypeService
    {
        Task<BaseResponse<CourseType>> CreateAsync(string name);

        Task<BaseResponse<CourseType>> UpdateAsync(CourseTypeForUpdationDto courseTypeDto);

        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<CourseType, bool>> expression);

        Task<BaseResponse<CourseType>> GetAsync(Expression<Func<CourseType, bool>> expression);

        Task<BaseResponse<IEnumerable<CourseType>>> GetAllAsync(PaginationParams @params, Expression<Func<Course, bool>> expression = null);
    }
}
