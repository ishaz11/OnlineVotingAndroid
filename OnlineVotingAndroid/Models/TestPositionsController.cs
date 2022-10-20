using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineVotingAndroid.Models
{
    public class TestPositionsController : Controller
    {
        private OnlineVotingDbContext db = new OnlineVotingDbContext();

        // GET: TestPositions
        public ActionResult Index()
        {
            var positions = db.Positions.Include(p => p.Election);
            return View(positions.ToList());
        }

        // GET: TestPositions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // GET: TestPositions/Create
        public ActionResult Create()
        {
            ViewBag.ElectionID = new SelectList(db.Elections, "ElectionID", "ElectionName");
            return View();
        }

        // POST: TestPositions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PositionId,ElectionID,PositionName,Count,exclusive,Representative")] Position position)
        {
            if (ModelState.IsValid)
            {
                db.Positions.Add(position);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ElectionID = new SelectList(db.Elections, "ElectionID", "ElectionName", position.ElectionID);
            return View(position);
        }

        // GET: TestPositions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            ViewBag.ElectionID = new SelectList(db.Elections, "ElectionID", "ElectionName", position.ElectionID);
            return View(position);
        }

        // POST: TestPositions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PositionId,ElectionID,PositionName,Count,exclusive,Representative")] Position position)
        {
            if (ModelState.IsValid)
            {
                db.Entry(position).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ElectionID = new SelectList(db.Elections, "ElectionID", "ElectionName", position.ElectionID);
            return View(position);
        }

        // GET: TestPositions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: TestPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Position position = db.Positions.Find(id);
            db.Positions.Remove(position);
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
