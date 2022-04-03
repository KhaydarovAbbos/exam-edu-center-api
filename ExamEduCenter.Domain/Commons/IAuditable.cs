using ExamEduCenter.Domain.Enums;
using System;

namespace ExamEduCenter.Domain.Commons
{
    public interface IAuditable
    {
        public long Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public DateTime DeletedDate { get; set; }

        public ItemState State { get; set; }
    }
}
