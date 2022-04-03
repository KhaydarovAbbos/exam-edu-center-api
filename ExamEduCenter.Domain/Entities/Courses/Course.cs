using ExamEduCenter.Domain.Commons;
using ExamEduCenter.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamEduCenter.Domain.Entities.Courses
{
    public class Course : IAuditable
    {
        public long Id { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(CourseTypeId))]
        public CourseType CourseType { get; set; }

        public long CourseTypeId { get; set; }

        public string Author { get; set; }

        public string Image { get; set; }

        public long WievCount { get; set; } = 0;

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public DateTime DeletedDate { get; set; }

        public ItemState State { get; set; }

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
