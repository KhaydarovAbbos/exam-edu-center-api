using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamEduCenter.Domain.Commons
{
    public class BaseResponse<T>
    {
        public int? Code { get; set; }

        public T Data { get; set; }

        public ErrorResponse Error { get; set; }
    }
}
