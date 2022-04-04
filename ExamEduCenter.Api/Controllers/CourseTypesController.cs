using ExamEduCenter.Domain.Commons;
using ExamEduCenter.Domain.Configuration;
using ExamEduCenter.Domain.Entities.Courses;
using ExamEduCenter.Domain.Enums;
using ExamEduCenter.Service.DTOs.Courses;
using ExamEduCenter.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamEduCenter.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class CourseTypesController : ControllerBase
    {
        private readonly ICourseTypeService courseTypeService;

        public CourseTypesController(ICourseTypeService courseTypeService)
        {
            this.courseTypeService = courseTypeService;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<CourseType>>> Create(string name)
        {
            var result = await courseTypeService.CreateAsync(name);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(long id)
        {
            var result = await courseTypeService.DeleteAsync(p => p.Id == id);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<CourseType>>> Get(long id)
        {
            var result = await courseTypeService.GetAsync(p => p.Id == id && p.State != ItemState.Deleted);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<CourseType>>>> GetAll([FromRoute] PaginationParams @params)
        {
            var result = await courseTypeService.GetAllAsync(@params);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse<CourseType>>> Update(CourseTypeForUpdationDto courseTypeDto)
        {
            var result = await courseTypeService.UpdateAsync(courseTypeDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }
    }
}
