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
    public class Students1Controller : Controller
    {
        private OnlineVotingDbContext db = new OnlineVotingDbContext();

        // GET: Students1
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s._YearAndSection);
            return View(students.ToList());
        }

        // GET: Students1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // GET: Students1/Create
        public ActionResult Create()
        {
            ViewBag.YearAndSectionID = new SelectList(db._YearAndSections, "YearAndSectionID", "Grade");
            return View();
        }

        // POST: Students1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,StudentSchoolID,FirstName,LastName,Password,Date,YearnSection,isEnable,YearAndSectionID,Photo")] Students students)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(students);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.YearAndSectionID = new SelectList(db._YearAndSections, "YearAndSectionID", "Grade", students.YearAndSectionID);
            return View(students);
        }

        // GET: Students1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            ViewBag.YearAndSectionID = new SelectList(db._YearAndSections, "YearAndSectionID", "Grade", students.YearAndSectionID);
            return View(students);
        }

        // POST: Students1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,StudentSchoolID,FirstName,LastName,Password,Date,YearnSection,isEnable,YearAndSectionID,Photo")] Students students)
        {
            if (ModelState.IsValid)
            {
                db.Entry(students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.YearAndSectionID = new SelectList(db._YearAndSections, "YearAndSectionID", "Grade", students.YearAndSectionID);
            return View(students);
        }

        // GET: Students1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // POST: Students1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Students students = db.Students.Find(id);
            db.Students.Remove(students);
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
