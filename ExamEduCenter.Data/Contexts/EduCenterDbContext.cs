using ExamEduCenter.Domain.Entities.Courses;
using Microsoft.EntityFrameworkCore;

namespace ExamEduCenter.Data.Contexts
{
    public class EduCenterDbContext : DbContext
    {
        public EduCenterDbContext(DbContextOptions<EduCenterDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<CourseType> CourseTypes { get; set; }
    }
}
