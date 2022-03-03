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
    public class SamplePersonsController : Controller
    {
        private OnlineVotingDbContext db = new OnlineVotingDbContext();

        // GET: SamplePersons
        public ActionResult Index()
        {
            return View(db.SamplePersons.ToList());
        }

        // GET: SamplePersons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SamplePerson samplePerson = db.SamplePersons.Find(id);
            if (samplePerson == null)
            {
                return HttpNotFound();
            }
            return View(samplePerson);
        }

        // GET: SamplePersons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SamplePersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,StudentID,FirstName,LastName,Password,Date,YearnSection,Role,isEnable")] SamplePerson samplePerson)
        {
            samplePerson.Role = "Student";
            if (ModelState.IsValid)
            {
                
                //samplePerson.Date = DateTime.ParseExact(samplePerson.Date, "yyyy-MM-dd",
                //                       System.Globalization.CultureInfo.InvariantCulture);
                db.SamplePersons.Add(samplePerson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(samplePerson);
        }

        // GET: SamplePersons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SamplePerson samplePerson = db.SamplePersons.Find(id);
            if (samplePerson == null)
            {
                return HttpNotFound();
            }
            return View(samplePerson);
        }

        // POST: SamplePersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,StudentID,FirstName,LastName,Password,Date,YearnSection,Role,isEnable")] SamplePerson samplePerson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(samplePerson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(samplePerson);
        }

        // GET: SamplePersons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SamplePerson samplePerson = db.SamplePersons.Find(id);
            if (samplePerson == null)
            {
                return HttpNotFound();
            }
            return View(samplePerson);
        }

        // POST: SamplePersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SamplePerson samplePerson = db.SamplePersons.Find(id);
            db.SamplePersons.Remove(samplePerson);
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
