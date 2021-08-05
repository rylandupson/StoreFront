using StoreFront.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreFront.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GenresController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        // GET: Genres
        public ActionResult Index()
        {
            return View(db.Genres.ToList());
        }

        #region AJAX
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult AjaxDelete(int id)
        {
            Genre genre = db.Genres.Find(id);
            db.Genres.Remove(genre);
            db.SaveChanges();

            string confirmMessage = string.Format("Deleted Genre '{0}' from the database", genre.GenreName);
            return Json(new { id = id, message = confirmMessage });
        }//end AjaxDelete

        [HttpGet]
        public PartialViewResult GenreDetails(int id)
        {
            Genre genre = db.Genres.Find(id);
            return PartialView(genre);
        }//end GenreDetails

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AjaxCreate(Genre genre)
        {
            db.Genres.Add(genre);
            db.SaveChanges();
            return Json(genre);
        }//end AjaxCreate

        [HttpGet]
        public PartialViewResult GenreEdit(int id)
        {
            Genre genre = db.Genres.Find(id);
            return PartialView(genre);
        }//end GenreEdit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AjaxEdit(Genre genre)
        {
            db.Entry(genre).State = EntityState.Modified;
            db.SaveChanges();
            return Json(genre);
        }//end AjaxEdit
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }//end Dispose
    }//end class
}//end namespace