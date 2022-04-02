using Microsoft.AspNetCore.Http;

namespace ExamEduCenter.Service.Helpers
{
    public class HttpContextHelper
    {
        public static IHttpContextAccessor Acessor;

        public static HttpContext Context => Acessor?.HttpContext;

        public static IHeaderDictionary ResponseHeader => Context?.Response?.Headers;
    }
}
