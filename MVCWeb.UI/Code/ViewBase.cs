using System.Web.Mvc;

namespace MVCWeb.UI
{
    public abstract class ViewBase<TModel> : WebViewPage<TModel>
    {
        public Grid Grid { get; set; }

        protected ViewBase()
        {
            Grid = new Grid(ViewBag);
        }

        public MvcHtmlString RenderServerMessage()
        {
            var htmlString = string.Empty;

            var message = ServerMessages.GetMessage(TempData);

            if (!string.IsNullOrEmpty(message))
            {
                htmlString = htmlString + string.Format("<div class='message'>{0}</div>", message);
            }

            var error = ServerMessages.GetError(TempData);
            if (!string.IsNullOrEmpty(error))
            {
                htmlString = htmlString + string.Format("<div class='error-message'>{0}</div>", error);
            }

            return new MvcHtmlString(htmlString);
        }
    }
}