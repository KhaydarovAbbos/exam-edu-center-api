using AutoMapper;
using ExamEduCenter.Data.IRepositories;
using ExamEduCenter.Domain.Commons;
using ExamEduCenter.Domain.Configuration;
using ExamEduCenter.Domain.Entities.Courses;
using ExamEduCenter.Domain.Enums;
using ExamEduCenter.Service.DTOs.Courses;
using ExamEduCenter.Service.Extensions;
using ExamEduCenter.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExamEduCenter.Service.Services
{
    public class CourseTypeService : ICourseTypeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CourseTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<CourseType>> CreateAsync(string name)
        {
            var response = new BaseResponse<CourseType>();

            var courseType = await unitOfWork.CourseTypes.GetAsync(p => p.Name == name);

            if (courseType is not null)
            {
                response.Error = new ErrorResponse(400, "Course type is exsist");
                return response;
            }

            var mappedCourse = new CourseType()
            {
                Name = name
            };

            var result = await unitOfWork.CourseTypes.CreateAsync(mappedCourse);

            await unitOfWork.CompleteTaskAsync();

            response.Code = 200;
            response.Data = result;

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<CourseType, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            //check for exsist course
            var exsistCourseType = await unitOfWork.CourseTypes.GetAsync(expression);

            if (exsistCourseType is null)
            {
                response.Error = new ErrorResponse(404, "Course not found");
                return response;
            }

            //delete after checking success
            await unitOfWork.CourseTypes.UpdateAsync(exsistCourseType);

            exsistCourseType.Delete();


            await unitOfWork.CompleteTaskAsync();

            response.Code = 200;
            response.Data = true;

            return response;
        }

        public async Task<BaseResponse<IEnumerable<CourseType>>> GetAllAsync(PaginationParams @params, Expression<Func<Course, bool>> expression = null)
        {
            var response = new BaseResponse<IEnumerable<CourseType>>();

            var courseTypes = await unitOfWork.CourseTypes.GetAllAsync(p => p.State != ItemState.Deleted);

            response.Code = 200;
            response.Data = courseTypes.ToPagedList(@params);

            return response;
        }

        public async Task<BaseResponse<CourseType>> GetAsync(Expression<Func<CourseType, bool>> expression)
        {
            var response = new BaseResponse<CourseType>();

            var courseType = await unitOfWork.CourseTypes.GetAsync(expression);

            //check course
            if (courseType is null)
            {
                response.Error = new ErrorResponse(404, "Course not found");
                return response;
            }

            response.Code = 200;
            response.Data = courseType;

            return response;
        }

        public async Task<BaseResponse<CourseType>> UpdateAsync(CourseTypeForUpdationDto courseTypeDto)
        {
            var response = new BaseResponse<CourseType>();

            var exsistCourseType = await unitOfWork.CourseTypes.GetAsync(p => p.Id == courseTypeDto.Id);

            if (exsistCourseType is null)
            {
                response.Error = new ErrorResponse(404, "Course not found");
            }

            exsistCourseType = mapper.Map(courseTypeDto, exsistCourseType);

            exsistCourseType.Update();

            var result = await unitOfWork.CourseTypes.UpdateAsync(exsistCourseType);

            await unitOfWork.CompleteTaskAsync();

            response.Code = 200;
            response.Data = result;

            return response;
        }
    }
}
