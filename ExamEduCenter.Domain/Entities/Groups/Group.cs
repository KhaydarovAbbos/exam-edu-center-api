using ExamEduCenter.Domain.Commons;
using ExamEduCenter.Domain.Entities.Courses;
using ExamEduCenter.Domain.Entities.Students;
using ExamEduCenter.Domain.Entities.Teachers;
using ExamEduCenter.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamEduCenter.Domain.Entities.Groups
{
    public class Group : IAuditable
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid TeacherId { get; set; }

        [ForeignKey(nameof(TeacherId))]
        public Teacher Teacher { get; set; }

        public Guid CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public DateTime DeletedDate { get; set; }

        public ItemState State { get; set; }

        public virtual ICollection<Student> Students { get; set; }

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
