namespace EduUp.Service.Common.Utils
{
    public class PagenationMetaData
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
        public int PageSize { get; set; }

        public PagenationMetaData(int totalCount, int pageSize, int pageIndex)
        {
            CurrentPage = (int)pageIndex;
            TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            HasNext = pageIndex < TotalPages;
            HasPrevious = pageIndex > 1;
            PageSize = pageSize;
        }
    }
}
