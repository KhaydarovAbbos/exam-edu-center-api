using ExamEduCenter.Data.Contexts;
using ExamEduCenter.Data.IRepositories;
using ExamEduCenter.Domain.Entities.Courses;

namespace ExamEduCenter.Data.Repositories
{
    public class CourseTypeRepository : GenericRepository<CourseType>, ICourseTypeRepository
    {
        public CourseTypeRepository(EduCenterDbContext eduCenterDbContext) : base(eduCenterDbContext)
        {
        }
    }
}
