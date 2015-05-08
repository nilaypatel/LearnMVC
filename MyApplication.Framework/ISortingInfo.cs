namespace MyApplication.Framework
{
    public interface ISortingInfo
    {
        string Sort { get; set; }

        SortDirection SortDirection { get; set; }
    }

    public class SortingInfo : ISortingInfo
    {
        public string Sort { get; set; }

        public SortDirection SortDirection { get; set; }
    }

    public enum SortDirection
    {
        Ascending,

        Descending
    }
}