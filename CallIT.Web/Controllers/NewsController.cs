﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallIT.Web.Controllers
{
    public class NewsController : _BaseController
    {
        // GET: News
        public ActionResult Index()
        {
            return View();
        }
    }
}