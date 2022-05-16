using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineVotingAndroid.Models;

namespace OnlineVotingAndroid.Controllers
{
    public class _YearAndSectionController : Controller
    {
        private OnlineVotingDbContext db = new OnlineVotingDbContext();

        // GET: _YearAndSection
        public ActionResult Index()
        {
            return View(db._YearAndSections.ToList());
        }

        // GET: _YearAndSection/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _YearAndSection _YearAndSection = db._YearAndSections.Find(id);
            if (_YearAndSection == null)
            {
                return HttpNotFound();
            }
            return View(_YearAndSection);
        }

        // GET: _YearAndSection/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: _YearAndSection/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YearAndSectionID,Grade")] _YearAndSection _YearAndSection)
        {
            if (ModelState.IsValid)
            {
                db._YearAndSections.Add(_YearAndSection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(_YearAndSection);
        }

        // GET: _YearAndSection/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _YearAndSection _YearAndSection = db._YearAndSections.Find(id);
            if (_YearAndSection == null)
            {
                return HttpNotFound();
            }
            return View(_YearAndSection);
        }

        // POST: _YearAndSection/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YearAndSectionID,Grade")] _YearAndSection _YearAndSection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(_YearAndSection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(_YearAndSection);
        }

        // GET: _YearAndSection/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _YearAndSection _YearAndSection = db._YearAndSections.Find(id);
            if (_YearAndSection == null)
            {
                return HttpNotFound();
            }
            return View(_YearAndSection);
        }

        // POST: _YearAndSection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _YearAndSection _YearAndSection = db._YearAndSections.Find(id);
            db._YearAndSections.Remove(_YearAndSection);
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
