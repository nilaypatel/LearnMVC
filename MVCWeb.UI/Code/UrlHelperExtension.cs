using System;
using System.Linq.Expressions;
using System.Web.Mvc;


namespace MVCWeb.UI
{
    public static class UrlHelperExtension
    {
        public static string Action<TController>(this UrlHelper urlHelper,Expression<Action<TController>> action)
            where TController : Controller
        {
            var routeValue = Microsoft.Web.Mvc.Internal.ExpressionHelper.GetRouteValuesFromExpression(action);

            return urlHelper.Action(null, routeValue);
        }
    }
}