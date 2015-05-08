using System.Linq;
using System.Web.Mvc;
using MVCWeb.UI.Models.GridToolbar;
using MyApplication.Framework;

namespace MVCWeb.UI.Controllers
{
    public class GridToolbarController : ControllerBase
    {
        public ActionResult Index(IGridInfo grid)
        {
            var index = new Index
            {
                CallbackUrl = grid.Url, 
                PagingInfo = grid.PagingInfo
            };

            return Display(index);
        }

        public ActionResult Pagination(IPagingInfo pagingInfo)
        {
            var pagination = new Pagination
            {
                CurrentPage = 1,
                PageNumbers = Enumerable.Range(1, 2).ToArray(),
                PageSize = 5,
                TotalRecords = 6,
                TotalPages = 2,
                ShowingFrom = 1,
                ShowingTo = 5
            };

            return Display(pagination);
        }

    }
}
