using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Esportiva.Models
{
    public class SessionCheck : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            if (session != null && session["user"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                                { "Controller", "" },
                                { "Action", "" }
                                });
            }
        }
    }
}