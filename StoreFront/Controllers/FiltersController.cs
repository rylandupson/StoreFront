using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreFront.DATA;
using PagedList;
using PagedList.Mvc;

namespace StoreFront.Controllers
{
    public class FiltersController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        // GET: Filters
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Clientside()
        {
            var games = db.Games.Include(g => g.Genre);
            return View(games.ToList());
        }

        public ActionResult Paging(string searchString, int page = 1)
        {
            int pageSize = 6;

            var games = db.Games.OrderBy(g => g.GameTitles).ToList();

            #region Search Func
            if (!String.IsNullOrEmpty(searchString))
            {
                games = (from g in games
                         where g.GameTitles.ToLower().Contains(searchString.ToLower())
                         select g).ToList();
            }

            ViewBag.SearchString = searchString;
            #endregion

            return View(games.ToPagedList(page, pageSize));
        }
    }
}