namespace MyApplication.Framework
{
    public interface IPagingInfo
    {
        int TotalRecords { get; set; }

        int Skip { get; }

        int PageNumber { get; set; }

        int PageSize { get; set; }
    }

    public class PagingInfo : IPagingInfo
    {
        public PagingInfo()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        public int TotalRecords { get; set; }

        public int Skip 
        {
            get
            {
                return PageNumber > 0 && PageSize > 0 
                    ? (PageNumber - 1) * PageSize 
                    : 0;
            }
        }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}