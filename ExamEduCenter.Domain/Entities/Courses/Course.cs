using ExamEduCenter.Domain.Commons;
using ExamEduCenter.Domain.Enums;
using System;

namespace ExamEduCenter.Domain.Entities.Courses
{
    public class Course : IAuditable
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public ushort Duration { get; set; }

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
