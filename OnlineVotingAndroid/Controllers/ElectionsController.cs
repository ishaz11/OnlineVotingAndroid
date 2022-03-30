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
    public class ElectionsController : Controller
    {
        private OnlineVotingDbContext db = new OnlineVotingDbContext();

        // GET: Elections
        public ActionResult Index()
        {
            return View(db.Elections.ToList());
        }

        // GET: Elections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Election election = db.Elections.Find(id);
            if (election == null)
            {
                return HttpNotFound();
            }
            return View(election);
        }

        // GET: Elections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Elections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ElectionID,ElectionName,IsActive")] Election election)
        {
            if (ModelState.IsValid)
            {
                if (election.IsActive == true)
                {
                    var ElectionList = (from x in db.Elections
                                        where x.IsActive == true
                                        select x).ToList();
                    foreach (Election e in ElectionList)
                    {
                        e.IsActive = false;
                    }
                    db.SaveChanges();
                }
                
                
                                   
                db.Elections.Add(election);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(election);
        }

        // GET: Elections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Election election = db.Elections.Find(id);
            if (election == null)
            {
                return HttpNotFound();
            }
            return View(election);
        }

        // POST: Elections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ElectionID,ElectionName,IsActive")] Election election)
        {
            if (ModelState.IsValid)
            {
                if (election.IsActive == true)
                {
                    var ElectionList = (from x in db.Elections
                                        where x.IsActive == true
                                        select x).ToList();
                    foreach (Election e in ElectionList)
                    {
                        e.IsActive = false;
                    }
                    
                }

                db.Entry(election).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(election);
        }

        // GET: Elections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Election election = db.Elections.Find(id);
            if (election == null)
            {
                return HttpNotFound();
            }
            return View(election);
        }

        // POST: Elections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Election election = db.Elections.Find(id);
            db.Elections.Remove(election);
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
