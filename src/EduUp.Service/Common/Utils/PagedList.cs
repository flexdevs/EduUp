using Microsoft.EntityFrameworkCore;

namespace EduUp.Service.Common.Utils
{
    public class PagedList<T> : List<T>
    {
        public PagenationMetaData MetaData { get; set; } = default!;

        public PagedList(List<T> items, int count, PagenationParams @params)
        {
            MetaData = new PagenationMetaData(count, @params.PageSize, @params.PageNumber);
            AddRange(items);
        }
        public async static Task<PagedList<T>> ToPagedListAsync(IQueryable<T> query, PagenationParams @params)
        {
            var count = await query.CountAsync();
            var items = await query.Skip((@params.PageNumber - 1) * @params.PageSize)
                                    .Take(@params.PageSize).ToListAsync();
            return new PagedList<T>(items, count, @params);
        }
        public static PagedList<T> ListToPagedList(List<T> list, int count, PagenationParams @params)
        {
            return new PagedList<T>(list, count, @params);
        }
    }
}
