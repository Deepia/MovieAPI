using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MovieAPI.Helpers
{
    public static class HttpContextExtensions
    {
        public async static Task InsertParameteresPaginationInHeader<T>(
            this HttpContext httpContext, IQueryable<T> queryable)
        {
            if(httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }
            double count = await queryable.CountAsync();
            httpContext.Response.Headers.Add("totalAmountofRecords", count.ToString());
        }
    }
}
