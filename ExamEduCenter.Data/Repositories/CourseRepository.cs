using ExamEduCenter.Data.Contexts;
using ExamEduCenter.Data.IRepositories;
using ExamEduCenter.Domain.Entities.Courses;

namespace ExamEduCenter.Data.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(EduCenterDbContext eduCenterDbContext) : base(eduCenterDbContext)
        {
        }
    }
}
