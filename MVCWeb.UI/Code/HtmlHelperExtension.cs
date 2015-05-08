using System.Web.Mvc;
using MVCWeb.UI.Controllers;
using MyApplication.Framework;
using Microsoft.Web.Mvc;

namespace MVCWeb.UI
{
    public static class HtmlHelperExtension
    {
        public static void RenderGridToolbar(this HtmlHelper htmlHelper, IGridInfo gridInfo)
        {
            htmlHelper.RenderAction<GridToolbarController>(c => c.Index(gridInfo));
        }
    }
}