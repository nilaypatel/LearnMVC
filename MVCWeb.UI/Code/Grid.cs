using System;
using System.Web;
using MyApplication.Framework;
using SortDirection = MyApplication.Framework.SortDirection;

namespace MVCWeb.UI
{
    public class Grid
    {
        private readonly dynamic viewBag;

        public Grid(dynamic viewbag)
        {
            viewBag = viewbag;
        }

        public IGridInfo GridInfo {
            get
            {
                if (viewBag.GridInfo == null)
                {
                    viewBag.GridInfo = new GridInfo
                    {
                        PagingInfo = GetPagingInfo(),
                        SortingInfo = GetSortingInfo()
                    };
                }

                return viewBag.GridInfo;
            }
        }

        private IPagingInfo GetPagingInfo()
        {
            var request = HttpContext.Current.Request;

            int pageNumber;
            var hasPageNumber = int.TryParse(request.QueryString["pn"], out pageNumber);
            int? pageSize = Convert.ToInt32(request.QueryString["ps"]);

            return hasPageNumber
                ? new PagingInfo {PageNumber = pageNumber, PageSize = pageSize.Value}
                : new PagingInfo();
        }

        private ISortingInfo GetSortingInfo()
        {
            var request = HttpContext.Current.Request;

            if (request["sort"] == null)
            {
                return new SortingInfo();
            }

            var sort = request["sort"];
            var direction = request["dir"];

            var sortDirection = SortDirection.Ascending;

            Enum.TryParse(direction, out sortDirection);

            return new SortingInfo
            {
                Sort = sort,
                SortDirection = sortDirection
            };
        }
    }
}