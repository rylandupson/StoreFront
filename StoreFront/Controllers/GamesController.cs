using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreFront.DATA;
using StoreFront.Models;
using StoreFront.Utilities;

namespace StoreFront.Controllers
{
    public class GamesController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        // GET: Games
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var games = db.Games.Include(g => g.Console).Include(g => g.Genre).Include(g => g.Publisher).Include(g => g.StockStatus);
            return View(games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        public ActionResult AddToCart(int quanity, int gameID)
        {
            Dictionary<int, CartItemViewModel> shoppingCart = null;

            if (Session["cart"] != null)
            {
                shoppingCart = (Dictionary<int, CartItemViewModel>)Session["cart"];
            }
            else
            {
                shoppingCart = new Dictionary<int, CartItemViewModel>();
            }

            Game product = db.Games.Where(g => g.GameID == gameID).FirstOrDefault();

            if (product == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                CartItemViewModel item = new CartItemViewModel(quanity, product);

                if (shoppingCart.ContainsKey(product.GameID))
                {
                    shoppingCart[product.GameID].Quanity += quanity;
                }
                else
                {
                    shoppingCart.Add(product.GameID, item);
                }

                Session["cart"] = shoppingCart;
            }

            return RedirectToAction("Index", "ShoppingCart");
        }//end AddToCart

        // GET: Games/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.ConsoleID = new SelectList(db.Consoles, "ConsoleID", "ConsoleName");
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName");
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName");
            ViewBag.StockID = new SelectList(db.StockStatus1, "StockID", "IsInStock");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameID,GameTitles,GenreID,PublisherID,StockID,ConsoleID,Price,TotalSales,ReleaseDate,Description,Image")] Game game, HttpPostedFileBase gameCover)
        {
            if (ModelState.IsValid)
            {
                #region File Upload
                string file = "NoImage.png";

                if (gameCover != null)
                {
                    file = gameCover.FileName;
                    string ext = file.Substring(file.LastIndexOf('.'));
                    string[] goodExts = { ".jpeg", ".jpg", ".jfif", ".png", ".gif" };

                    if (goodExts.Contains(ext.ToLower()) && gameCover.ContentLength <= 4194304)
                    {
                        file = Guid.NewGuid() + ext;

                        #region Resize Image
                        string savePath = Server.MapPath("~/Content/images/gamesCovers/");

                        Image convertedImage = Image.FromStream(gameCover.InputStream);

                        int maxImageSize = 500;

                        int maxThumbSize = 100;

                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);
                        #endregion
                    }
                    game.Image = file;
                }
                #endregion

                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConsoleID = new SelectList(db.Consoles, "ConsoleID", "ConsoleName", game.ConsoleID);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", game.GenreID);
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName", game.PublisherID);
            ViewBag.StockID = new SelectList(db.StockStatus1, "StockID", "IsInStock", game.StockID);
            return View(game);
        }

        // GET: Games/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConsoleID = new SelectList(db.Consoles, "ConsoleID", "ConsoleName", game.ConsoleID);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", game.GenreID);
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName", game.PublisherID);
            ViewBag.StockID = new SelectList(db.StockStatus1, "StockID", "IsInStock", game.StockID);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameID,GameTitles,GenreID,PublisherID,StockID,ConsoleID,Price,TotalSales,ReleaseDate,Description,Image")] Game game, HttpPostedFileBase gameCover)
        {
            if (ModelState.IsValid)
            {
                #region File Upload
                string file = game.Image;

                if (gameCover != null)
                {
                    file = gameCover.FileName;

                    string ext = file.Substring(file.LastIndexOf('.'));

                    string[] goodExts = { ".jpeg", ".jpg", ".jfif", ".png", ".gif" };

                    if (goodExts.Contains(ext.ToLower()) && gameCover.ContentLength <= 4194304)
                    {
                        file = Guid.NewGuid() + ext;
                        #region Resize Image
                        string savePath = Server.MapPath("~/Content/images/gamesCovers/");

                        Image convertedImage = Image.FromStream(gameCover.InputStream);

                        int maxImageSize = 500;

                        int maxThumbSize = 100;

                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);
                        #endregion
                        if (game.Image != null && game.Image != "NoImage.png")
                        {
                            string path = Server.MapPath("~/Content/images/gamesCovers/");
                            ImageUtility.Delete(path, game.Image);
                        }
                        game.Image = file;
                    }
                }
                #endregion

                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConsoleID = new SelectList(db.Consoles, "ConsoleID", "ConsoleName", game.ConsoleID);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", game.GenreID);
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName", game.PublisherID);
            ViewBag.StockID = new SelectList(db.StockStatus1, "StockID", "IsInStock", game.StockID);
            return View(game);
        }

        // GET: Games/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);

            string path = Server.MapPath("~/Content/images/gamesCovers/");
            ImageUtility.Delete(path, game.Image);

            db.Games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
