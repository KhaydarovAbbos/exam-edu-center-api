using ExamEduCenter.Domain.Commons;
using ExamEduCenter.Domain.Entities.Courses;
using ExamEduCenter.Domain.Enums;
using System;
using System.Collections.Generic;

namespace ExamEduCenter.Domain.Entities.Teachers
{
    public class Teacher : IAuditable
    {
        public Guid Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public DateTime DeletedDate { get; set; }

        public ItemState State { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public void Create()
        {
            CreatedDate = DateTime.Now;
            State = ItemState.Created;
        }

        public void Update()
        {
            UpdatedDate = DateTime.Now;
            State = ItemState.Updated;
        }

        public void Delete()
        {
            DeletedDate = DateTime.Now;
            State = ItemState.Deleted;
        }
    }
}
