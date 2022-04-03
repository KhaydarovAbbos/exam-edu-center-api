using ExamEduCenter.Data.Contexts;
using ExamEduCenter.Data.IRepositories;
using System;
using System.Threading.Tasks;

namespace ExamEduCenter.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EduCenterDbContext eduCenterDbContext;

        public UnitOfWork(EduCenterDbContext eduCenterDbContext)
        {
            this.eduCenterDbContext = eduCenterDbContext;

            // Initialize repositories
            Courses = new CourseRepository(eduCenterDbContext);
            CourseTypes = new CourseTypeRepository(eduCenterDbContext);
        }

        public ICourseRepository Courses { get; private set; }

        public ICourseTypeRepository CourseTypes { get; private set; }


        public async Task CompleteTaskAsync()
        {
            await eduCenterDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
