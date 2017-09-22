using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallIT.Web.Controllers
{
    public class AdminController : _BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}