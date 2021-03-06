﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ITY502.Controllers
{
    public class PublicController : Controller
    {
        // GET: Public
        protected override void OnActionExecuting(ActionExecutingContext filterContext)

        {

            HttpSessionStateBase session = filterContext.HttpContext.Session;

            Controller controller = filterContext.Controller as Controller;


            if (session == null)
            {
                ViewBag.updateAccountMessage = "Session Expired";

                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new

                {

                    controller = "Home",

                    action = "Login"

                }));
            }
            else if (session != null && (session["UserType"].ToString()) != "Public")

            {

                ViewBag.updateAccountMessage = "Session Expired";

                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new

                {

                    controller = "Home",

                    action = "Login"

                }));

            }

            base.OnActionExecuting(filterContext);

        }
        public ActionResult PublicHomePage()
        {
            return View();
        }
    }
}