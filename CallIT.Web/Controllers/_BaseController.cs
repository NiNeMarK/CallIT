using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CallIT.Web.Controllers
{
    public class _BaseController : Controller
    {
        // GET: _Base
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            base.Initialize(requestContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            //if (filterContext.HttpContext.IsCustomErrorEnabled)
            //{
            filterContext.ExceptionHandled = true;
            TempData["ErrorFromUrl"] = Request.Url.AbsoluteUri;
            TempData["ExceptionError"] = filterContext.Exception;
            filterContext.Result = this.RedirectToAction("Index", "Home");
            //}
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //HttpContext ctx = HttpContext.Current;
            // If the browser session or authentication session has expired...
            if (Session["CurrentUser"] == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    // For AJAX requests, we're overriding the returned JSON result with a simple string,
                    // indicating to the calling JavaScript code that a redirect should be performed.
                    filterContext.Result = this.RedirectToAction("Index", "Home"); //new JsonResult { Data = "_Logon_" };
                }
                else
                {
                    // For round-trip posts, we're forcing a redirect to Home/TimeoutRedirect/, which
                    // simply displays a temporary 5 second notification that they have timed out, and
                    // will, in turn, redirect to the logon page.
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary {
                        { "Controller", "Home" },
                        { "Action", "Index" }
                });
                }
            }
            else
            {
                //var currentUser = (Viriyah.Agency.DataModel.UserModel)Session["CurrentUser"];
                //var curr_module = currentUser.appmodulelist;
                //var conname = filterContext.HttpContext.Request.RequestContext.RouteData.Values["controller"].ToString().ToLower();
                //var check_permission = (from q in curr_module where q.moduleName.ToLower() == conname select q).ToList();
                //if (check_permission.Count() == 0)
                //{
                //    TempData["message_error"] = "authentication to not access application.";
                //    // will, in turn, redirect to the logon page.
                //    filterContext.Result = new RedirectToRouteResult(
                //        new RouteValueDictionary {
                //    { "Controller", "Login" },
                //    { "Action", "Index" }
                //});
                //}
            }

            filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
            filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetNoStore();
            base.OnActionExecuting(filterContext);
        }
    }
}