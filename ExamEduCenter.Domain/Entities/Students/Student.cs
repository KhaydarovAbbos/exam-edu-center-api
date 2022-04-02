using ExamEduCenter.Domain.Commons;
using ExamEduCenter.Domain.Enums;
using System;

namespace ExamEduCenter.Domain.Entities.Students
{
    public class Student : IAuditable
    {
        public Guid Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Phone { get; set; }

        public Guid GroupId { get; set; }

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
