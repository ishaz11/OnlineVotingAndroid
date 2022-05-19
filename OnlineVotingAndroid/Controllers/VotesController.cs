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
    public class VotesController : Controller
    {
        private OnlineVotingDbContext db = new OnlineVotingDbContext();

        // GET: Votes
        public ActionResult Index()
        {
            var votes = db.Votes.Include(v => v.Candidates).Include(v => v.Election).Include(v => v.Students).Where(x =>x.Election.IsActive == true);
            return View(votes.ToList());
        }

        public ActionResult AlreadyVoted()
        {
            var activeVotes = db.Votes.Where(x => x.Election.IsActive == true);
            var students = db.Students.Where(x => x.isEnable == true);
            ViewBag.alreadyVoted = students.Where(x => activeVotes.Any(a => a.StudentID == x.StudentID));
            //ViewBag.alreadyVoted = from s in students
            //                   join v in db.Votes on s.StudentID equals v.StudentID
            //                   where v.Election.IsActive == true
            //                   select s;
                               



            var votes = db.Votes.Include(v => v.Candidates).Include(v => v.Election).Include(v => v.Students).Where(x => x.Election.IsActive == true);
            return View();
        }

        public ActionResult Remaining()
        {
            var students = db.Students.Where(x => x.isEnable == true);
            var activeVotes = db.Votes.Where(x => x.Election.IsActive == true);
            ViewBag.alreadyVoted = students.Where(v => !activeVotes.Any(s => s.StudentID == v.StudentID ));
            return View();
        }

        // GET: Votes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote vote = db.Votes.Find(id);
            if (vote == null)
            {
                return HttpNotFound();
            }
            return View(vote);
        }

        // GET: Votes/Create
        public ActionResult Create()
        {
            ViewBag.CandidateID = new SelectList(db.Candidates, "CandidateID", "CandidateID");
            ViewBag.ElectionID = new SelectList(db.Elections.Where(x=>x.IsActive == true), "ElectionID", "ElectionName");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentSchoolID");
            return View();
        }

        // POST: Votes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VoteID,StudentID,CandidateID,ElectionID,DateVoted")] Vote vote)
        {
            vote.DateVoted = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Votes.Add(vote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CandidateID = new SelectList(db.Candidates, "CandidateID", "CandidateID", vote.CandidateID);
            ViewBag.ElectionID = new SelectList(db.Elections, "ElectionID", "ElectionName", vote.ElectionID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentSchoolID", vote.StudentID);
            return View(vote);
        }

        // GET: Votes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote vote = db.Votes.Find(id);
            if (vote == null)
            {
                return HttpNotFound();
            }
            ViewBag.CandidateID = new SelectList(db.Candidates, "CandidateID", "CandidateID", vote.CandidateID);
            ViewBag.ElectionID = new SelectList(db.Elections, "ElectionID", "ElectionName", vote.ElectionID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentSchoolID", vote.StudentID);
            return View(vote);
        }

        // POST: Votes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VoteID,StudentID,CandidateID,ElectionID,DateVoted")] Vote vote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CandidateID = new SelectList(db.Candidates, "CandidateID", "CandidateID", vote.CandidateID);
            ViewBag.ElectionID = new SelectList(db.Elections, "ElectionID", "ElectionName", vote.ElectionID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentSchoolID", vote.StudentID);
            return View(vote);
        }

        // GET: Votes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote vote = db.Votes.Find(id);
            if (vote == null)
            {
                return HttpNotFound();
            }
            return View(vote);
        }

        // POST: Votes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vote vote = db.Votes.Find(id);
            db.Votes.Remove(vote);
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
