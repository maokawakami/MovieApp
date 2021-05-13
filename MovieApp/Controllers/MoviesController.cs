using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        private MoviesContext db = new MoviesContext();

        // GET: Movies
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        // GET: Movies/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Release,Kind,Price")] Movie movie)
        {

            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Release,Kind,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Search
        public ActionResult Search([Bind(Include = "Kind, Title")] SearchView model)
        {
            //検索機能
            //両方記載あり
            if (!string.IsNullOrEmpty(model.Kind) && !string.IsNullOrEmpty(model.Title))
            {
                var list = db.Movies.Where(item => item.Kind.IndexOf(model.Kind) == 0 
                                                && item.Title.IndexOf(model.Title) == 0).ToList();
                model.Movies = list;
            }

            //ジャンル名のみ記載
            else if (!string.IsNullOrEmpty(model.Kind) && string.IsNullOrEmpty(model.Title))
            {
                var list = db.Movies.Where(item => item.Kind.IndexOf(model.Kind) == 0).ToList();
                model.Movies = list;
            }

            //タイトル名のみ記載
            else if (string.IsNullOrEmpty(model.Kind) && !string.IsNullOrEmpty(model.Title))
            {
                var list = db.Movies.Where(item => item.Title.IndexOf(model.Title) == 0).ToList();
                model.Movies = list;
            }

            else
            {
                model.Movies = db.Movies.ToList();
            }

            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //モーダル
        public ActionResult View_modal()
        {
            return RedirectToAction("Search");
        }
        public async Task<ActionResult> ShowModal(int? id)
        {
            //ボタンから取得したIDに紐づくユーザー情報を取得
            var movies = await db.Movies.FirstOrDefaultAsync(m => m.Id == id);

            //呼び出したいモ－ダル用のViewを指定
　　　　　　//渡したいデータは第二引数とする
            return PartialView("View_modal", movies);
        }
    }
}
