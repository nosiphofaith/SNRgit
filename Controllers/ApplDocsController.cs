using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FileUpLoad1.Data;
using FileUpLoad1.Models;

namespace FileUpLoad1.Controllers
{
    public class ApplDocsController : Controller
    {
        private FileUpLoad1Context db = new FileUpLoad1Context();

        // GET: ApplDocs
        public ActionResult Index()
        {
            var applDocs = db.ApplDocs.Include(a => a.Categories);
            return View(applDocs.ToList());
        }

        // GET: ApplDocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplDocs applDocs = db.ApplDocs.Find(id);
            if (applDocs == null)
            {
                return HttpNotFound();
            }
            return View(applDocs);
        }

        // GET: ApplDocs/Create
        public ActionResult Create()
        {
            ViewBag.Doc_CategoryID = new SelectList(db.Categories, "Doc_CategoryID", "CateName");
            return View();
        }

        // POST: ApplDocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Doc_ID,Doc_Name,Doc_ImageURL,Doc_CategoryID")] ApplDocs applDocs)
        {
            if (ModelState.IsValid)
            {
                db.ApplDocs.Add(applDocs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Doc_CategoryID = new SelectList(db.Categories, "Doc_CategoryID", "CateName", applDocs.Doc_CategoryID);
            return View(applDocs);
        }

        // GET: ApplDocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplDocs applDocs = db.ApplDocs.Find(id);
            if (applDocs == null)
            {
                return HttpNotFound();
            }
            ViewBag.Doc_CategoryID = new SelectList(db.Categories, "Doc_CategoryID", "CateName", applDocs.Doc_CategoryID);
            return View(applDocs);
        }

        // POST: ApplDocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Doc_ID,Doc_Name,Doc_ImageURL,Doc_CategoryID")] ApplDocs applDocs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applDocs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Doc_CategoryID = new SelectList(db.Categories, "Doc_CategoryID", "CateName", applDocs.Doc_CategoryID);
            return View(applDocs);
        }

        // GET: ApplDocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplDocs applDocs = db.ApplDocs.Find(id);
            if (applDocs == null)
            {
                return HttpNotFound();
            }
            return View(applDocs);
        }

        // POST: ApplDocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApplDocs applDocs = db.ApplDocs.Find(id);
            db.ApplDocs.Remove(applDocs);
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
