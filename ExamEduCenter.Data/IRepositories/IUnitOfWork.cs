using System;
using System.Threading.Tasks;

namespace ExamEduCenter.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }

        ICourseTypeRepository CourseTypes { get; }

        Task CompleteTaskAsync();
    }
}
