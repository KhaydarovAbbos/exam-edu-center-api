using AutoMapper;
using ExamEduCenter.Data.IRepositories;
using ExamEduCenter.Domain.Commons;
using ExamEduCenter.Domain.Configuration;
using ExamEduCenter.Domain.Entities.Courses;
using ExamEduCenter.Domain.Enums;
using ExamEduCenter.Service.DTOs.Courses;
using ExamEduCenter.Service.Extensions;
using ExamEduCenter.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExamEduCenter.Service.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IConfiguration config;
        private readonly IHostingEnvironment env;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config, IHostingEnvironment env)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.config = config;
            this.env = env;
        }

        public async Task<BaseResponse<Course>> CreateAsync(CourseForCreationDto courseDto)
        {
            var response = new BaseResponse<Course>();

            //check course exsist
            var exsistStudent = await unitOfWork.Courses.GetAsync(p => p.Name == courseDto.Name && p.State != ItemState.Deleted);

            if (exsistStudent is not null)
            {
                response.Error = new ErrorResponse(400, "Course is exsist");
                return response;
            }

            var exsistCourseType = await unitOfWork.CourseTypes.GetAsync(p => p.Id == courseDto.CourseTypeId && p.State != ItemState.Deleted);

            if (exsistCourseType is null)
            {
                response.Error = new ErrorResponse(404, "Course type not found");

                return response;
            }

            //create after checking success
            var mappedCourse = mapper.Map<Course>(courseDto);

            mappedCourse.Image = await SaveFileAsync(courseDto.Image.OpenReadStream(), courseDto.Image.FileName);
            mappedCourse.Create();

            var result = await unitOfWork.Courses.CreateAsync(mappedCourse);

            string storagePath = config.GetSection("Storage:BaseUrl").Value;
            result.Image = storagePath + result.Image;

            await unitOfWork.CompleteTaskAsync();

            response.Code = 200;
            response.Data = result;

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Course, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            //check for exsist course
            var exsistCourse = await unitOfWork.Courses.GetAsync(expression);

            if (exsistCourse is null)
            {
                response.Error = new ErrorResponse(404, "Course not found");
                return response;
            }

            //delete after checking success
            exsistCourse.Delete();

            await unitOfWork.Courses.UpdateAsync(exsistCourse);

            await unitOfWork.CompleteTaskAsync();

            response.Code = 200;
            response.Data = true;

            return response;
        }

        public async Task<BaseResponse<IEnumerable<Course>>> GetAllAsync(PaginationParams @params, Expression<Func<Course, bool>> expression = null)
        {
            var response = new BaseResponse<IEnumerable<Course>>();

            var students = await unitOfWork.Courses.GetAllAsync(p => p.State != ItemState.Deleted);

            response.Code = 200;
            response.Data = students.ToPagedList(@params);

            return response;
        }

        public async Task<BaseResponse<Course>> GetAsync(Expression<Func<Course, bool>> expression)
        {
            var response = new BaseResponse<Course>();

            var course = await unitOfWork.Courses.GetAsync(expression);

            //check course
            if (course is null)
            {
                response.Error = new ErrorResponse(404, "Course not found");
                return response;
            }

            course.WievCount += 1;
            await unitOfWork.Courses.UpdateAsync(course);
            await unitOfWork.CompleteTaskAsync();

            response.Code = 200;
            response.Data = course;

            return response;
        }

        public async Task<BaseResponse<Course>> UpdateAsync(CourseForUpdatingDto courseDto)
        {
            var response = new BaseResponse<Course>();

            var exsistCourse = await unitOfWork.Courses.GetAsync(p => p.Id == courseDto.Id);

            if (exsistCourse is null)
            {
                response.Error = new ErrorResponse(404, "Course not found");

                return response;
            }

            var exsistCourseType = await unitOfWork.CourseTypes.GetAsync(p => p.Id == courseDto.CourseTypeId && p.State != ItemState.Deleted);

            if (exsistCourseType is null)
            {
                response.Error = new ErrorResponse(404, "Course type not found");
            }

            exsistCourse = mapper.Map(courseDto, exsistCourse);

            var result = await unitOfWork.Courses.UpdateAsync(exsistCourse);

            result.Update();

            await unitOfWork.CompleteTaskAsync();

            response.Code = 200;
            response.Data = result;

            return response;
        }

        public async Task<BaseResponse<Course>> SetImageAsync(long courseId, IFormFile file)
        {
            var response = new BaseResponse<Course>();

            var course = await unitOfWork.Courses.GetAsync(p => p.Id == courseId && p.State != ItemState.Deleted);

            if (course is null)
            {
                response.Error = new ErrorResponse(404, "Course not found");
                return response;
            }

            course.Image = await SaveFileAsync(file.OpenReadStream(), file.FileName);

            course.Update();

            var result = await unitOfWork.Courses.UpdateAsync(course);

            result.Update();

            string storagePath = config.GetSection("Storage:BaseUrl").Value;
            result.Image = storagePath + result.Image;

            await unitOfWork.CompleteTaskAsync();

            response.Code = 200;
            response.Data = result;

            return response;
        }

        public async Task<string> GetImageAsync(long courseId)
        {
            var course = await unitOfWork.Courses.GetAsync(p => p.Id == courseId);

            string storagePath = config.GetSection("Storage:ImageUrl").Value;
            string path = Path.Combine(env.WebRootPath, $"{storagePath}/{course.Image}");

            return path;
        }

        public async Task<string> SaveFileAsync(Stream file, string fileName)
        {
            fileName = Guid.NewGuid().ToString("N") + "_" + fileName;
            string storagePath = config.GetSection("Storage:ImageUrl").Value;
            string filePath = Path.Combine(env.WebRootPath, $"{storagePath}/{fileName}");
            FileStream mainFile = File.Create(filePath);
            await file.CopyToAsync(mainFile);
            mainFile.Close();

            return fileName;
        }

        public async Task<BaseResponse<Course>> UpdateCoureAuthor(long courseId, string Author)
        {
            var response = new BaseResponse<Course>();

            var course = await unitOfWork.Courses.GetAsync(p => p.Id == courseId && p.State != ItemState.Deleted);

            if (course is null)
            {
                response.Error = new ErrorResponse(404, "Course not found");
                return response;
            }

            course.Author = Author;
            course.Update();

            var result = await unitOfWork.Courses.UpdateAsync(course);
            await unitOfWork.CompleteTaskAsync();

            response.Code = 200;
            response.Data = result;

            return response;
        }
    }
}