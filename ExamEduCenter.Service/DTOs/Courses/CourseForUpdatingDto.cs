namespace ExamEduCenter.Service.DTOs.Courses
{
    public class CourseForUpdatingDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long CourseTypeId { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

    }
}
