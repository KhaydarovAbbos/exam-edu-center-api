namespace ExamEduCenter.Domain.Configuration
{
    public class PaginationParams
    {
        public const int maxPageSize = 50;
        public int pageSize;

        public int PageIndex { get => pageSize; set => pageSize = value > maxPageSize ? maxPageSize : value; }

        public int PageSize { get; set; }

    }
}
