using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurchasePageMVC.Security
{
    public class SessionValidate: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["User"] == null)
            {
                filterContext.Result = new RedirectResult("/User/Login");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}