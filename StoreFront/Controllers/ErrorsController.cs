﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreFront.Exceptions;

namespace StoreFront.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Unresolved()
        {
            return View();
        }
    }
}