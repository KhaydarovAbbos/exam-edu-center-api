using ExamEduCenter.Domain.Commons;
using ExamEduCenter.Domain.Configuration;
using ExamEduCenter.Domain.Entities.Courses;
using ExamEduCenter.Domain.Enums;
using ExamEduCenter.Service.DTOs.Courses;
using ExamEduCenter.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ExamEduCenter.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Course>>> Create([FromForm] CourseForCreationDto courseForCreationDto)
        {
            var result = await courseService.CreateAsync(courseForCreationDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete("{courseId}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(long courseId)
        {
            var result = await courseService.DeleteAsync(p => p.Id == courseId && p.State != ItemState.Deleted);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet("{courseId}")]
        public async Task<ActionResult<BaseResponse<Course>>> Get(long courseId)
        {
            var result = await courseService.GetAsync(p => p.Id == courseId && p.State != ItemState.Deleted);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<Course>>>> GetAll([FromRoute] PaginationParams @params)
        {
            var result = await courseService.GetAllAsync(@params);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse<Course>>> Update(CourseForUpdatingDto courseDto)
        {
            var result = await courseService.UpdateAsync(courseDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPost("Image")]
        public async Task<ActionResult<BaseResponse<Course>>> SetImage(long courseId, IFormFile image)
        {
            var result = await courseService.SetImageAsync(courseId, image);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPatch]
        public async Task<ActionResult<BaseResponse<Course>>> UpdateAuthor(long courseId, string Author)
        {
            var result = await courseService.UpdateCoureAuthor(courseId, Author);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet("Image")]
        public async Task<ActionResult> GetImage(long courseId)
        {
            var result = await courseService.GetImageAsync(courseId);

            if (result is null)
            {
                return StatusCode(404, "Course not fund");
            }
            byte[] image = await System.IO.File.ReadAllBytesAsync(result);
            return File(image, "octet/stream", Path.GetFileName(result));
        }

    }
}
