using Microsoft.AspNetCore.Http;

namespace ExamEduCenter.Service.DTOs.Courses
{
    public class CourseForCreationDto
    {
        public string Name { get; set; }

        public long CourseTypeId { get; set; }

        public string Author { get; set; }

        public IFormFile Image { get; set; }

        public string Description { get; set; }
    }
}
