namespace MyApplication.Framework
{
    public interface IGridInfo
    {
        string Url { get; set; }

        ISortingInfo SortingInfo { get; set; }

        IPagingInfo PagingInfo { get; set; }
    }

    public class GridInfo : IGridInfo
    {
        public string Url { get; set; }

        public ISortingInfo SortingInfo { get; set; }

        public IPagingInfo PagingInfo { get; set; }
    }
}