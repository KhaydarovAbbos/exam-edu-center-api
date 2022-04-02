using Microsoft.EntityFrameworkCore;
using System;

namespace ExamEduCenter.Data.Contexts
{
    public class EduCenterDbContext : DbContext
    {
        public EduCenterDbContext(DbContextOptions<EduCenterDbContext> options)
            :base(options)
        {

        }
    }
}
