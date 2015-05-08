using System.Web.Mvc;
using MVCWeb.UI.Models.Shared;

namespace MVCWeb.UI.Controllers
{
    public class ControllerBase : Controller
    {
        public Grid Grid { get; set; }

        public ControllerBase()
        {
            Grid = new Grid(ViewBag);
        }

        public ActionResult Display<TModel>(TModel model)
        {
            return View("_DisplayView", model);
        }

        public ActionResult Editor<TModel>(TModel model)
        {
            return View("_EditorView", model);
        }

        public ActionResult CloseDialogAndRedirect(string url)
        {
            var model = new CloseModel
            {
                Url = url,
                CloseAction = CloseAction.CloseAndRedirect
            };
            return View("_CloseDialog", model);
        }

    }
}
