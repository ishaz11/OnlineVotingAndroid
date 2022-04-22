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
    public class CandidatesController : Controller
    {
        private OnlineVotingDbContext db = new OnlineVotingDbContext();

        // GET: Candidates
        public ActionResult Index()
        {
            var candidates = db.Candidates.Include(c => c.Position).Include(c => c.Students).Where(c => c.Position.Election.IsActive == true);
            return View(candidates.ToList());
        }

        // GET: Candidates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // GET: Candidates/Create
        public ActionResult Create()
        {
            var position = from x in db.Positions
                           where x.Election.IsActive == true
                           select new
                           {
                               ID = x.PositionId,
                               Name = x.PositionName
                           };

            var student = from x in db.Students
                          orderby x.StudentID
                          select new
                          {
                              ID = x.StudentID,
                              Name = x.StudentID + " " + x.LastName + ", " + x.FirstName
                          };

            ViewBag.PositionId = new SelectList(position, "ID", "Name");
            ViewBag.StudentID = new SelectList(student, "ID", "Name");
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CandidateID,PositionId,StudentID")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                //candidate.PositionId = db.Positions.Where(x => x.Election.IsActive == true).Select(x => x.PositionId).FirstOrDefault();
                db.Candidates.Add(candidate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "PositionName", candidate.PositionId);
            ViewBag.StudentID = new SelectList(db.Students, "id", "StudentID", candidate.StudentID);
            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "PositionName", candidate.PositionId);
            ViewBag.StudentID = new SelectList(db.Students, "id", "StudentID", candidate.StudentID);
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CandidateID,PositionId,StudentID")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "PositionName", candidate.PositionId);
            ViewBag.StudentID = new SelectList(db.Students, "id", "StudentID", candidate.StudentID);
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidate candidate = db.Candidates.Find(id);
            db.Candidates.Remove(candidate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ActiveCandidates
        public ActionResult ActiveElection()
        {
            var candidates = db.Candidates.Include(c => c.Position).Where(c => c.Position.Election.IsActive == true).Include(c => c.Students);
            return View(candidates.ToList());
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
