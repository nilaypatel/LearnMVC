namespace MVCWeb.UI.Models.GridToolbar
{
    public class Pagination
    {
        public int CurrentPage { get; set; }

        public int[] PageNumbers { get; set; }

        public int PageSize { get; set; }

        public int ShowingFrom { get; set; }

        public int ShowingTo { get; set; }

        public int TotalRecords { get; set; }

        public bool HasMorePages { get; set; }

        public int TotalPages { get; set; }
    }
}