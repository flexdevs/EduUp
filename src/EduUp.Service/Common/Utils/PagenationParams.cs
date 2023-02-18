namespace EduUp.Service.Common.Utils
{
    public class PagenationParams
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PagenationParams(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public PagenationParams(int pageNumber)
        {
            PageNumber = pageNumber;
            PageSize = 10;
        }
    }
}
