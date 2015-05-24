using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Try426.Models;

namespace Try426.Controllers
{
    public class BooksManageController : Controller
    {
        private Try426BookContext db = new Try426BookContext();

        // GET: BooksManage
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Author);
            return View(books.ToList());
        }

        public ActionResult Autocomplete(string term)
        {
            var model = db.Books.Where(r => r.Name.StartsWith(term))
                                .Take(10)
                                .Select(r => new
                                {
                                    label = r.Name
                                });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(string q)
        {
            
            //var books;
            //if (q != null && q != "")
            //{
                var books = db.Books
                                .Include("Author")
                               .Where(a => a.Name.Contains(q))
                                .Take(10);

            

                if (Request.IsAjaxRequest())
                {
                    System.Threading.Thread.Sleep(3000); // on purpose 
                    return PartialView("_BookList", books);
                }
                return View(books);
            //}
            //else
            //    return View(books);
        }

        // GET: BooksManage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: BooksManage/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name");
            return View();
        }

        // POST: BooksManage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,AuthorId,Name,ISBN,PageCount,LastRead")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name", book.AuthorId);
            return View(book);
        }

        // GET: BooksManage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name", book.AuthorId);
            return View(book);
        }

        // POST: BooksManage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,AuthorId,Name,ISBN,PageCount,LastRead")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name", book.AuthorId);
            return View(book);
        }

        // GET: BooksManage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: BooksManage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
