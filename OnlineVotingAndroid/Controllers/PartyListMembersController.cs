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
    public class PartyListMembersController : Controller
    {
        private OnlineVotingDbContext db = new OnlineVotingDbContext();

        // GET: PartyListMembers
        public ActionResult Index()
        {
            var partyListMembers = db.PartyListMembers.Include(p => p.PartyLists).Include(p => p.Students);
            return View(partyListMembers.ToList());
        }

        // GET: PartyListMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartyListMember partyListMember = db.PartyListMembers.Find(id);
            if (partyListMember == null)
            {
                return HttpNotFound();
            }
            return View(partyListMember);
        }

        // GET: PartyListMembers/Create
        public ActionResult Create(int? Id)
        {
            var student = from x in db.Students
                          where x.StudentID == Id
                          orderby x.StudentID
                          select new
                          {
                              ID = x.StudentID,
                              Name = x.StudentSchoolID + " " + x.LastName + ", " + x.FirstName
                          };
            ViewBag.students = db.Students.Find(Id);
            ViewBag.PartyListID = new SelectList(db.PartyLists.Where(x => x.isEnable == true), "PartyListID", "PartyListName");
            ViewBag.StudentID = new SelectList(student, "ID", "Name");
            return View();
        }

        // POST: PartyListMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PartyListID,StudentID,isOfficer")] PartyListMember partyListMember)
        {
            if (ModelState.IsValid)
            {
                PartyListMember partyListMembertoDelete = db.PartyListMembers.Find(partyListMember.Id);
                if(partyListMembertoDelete != null)
                {
                    db.PartyListMembers.Remove(partyListMembertoDelete);
                    db.SaveChanges();
                }
                

                db.PartyListMembers.Add(partyListMember);
                db.SaveChanges();
                return RedirectToAction("Index", "Students");
            }

            ViewBag.PartyListID = new SelectList(db.PartyLists.Where(x => x.isEnable == true), "PartyListID", "PartyListName", partyListMember.PartyListID);
            ViewBag.StudentID = new SelectList(db.Students, "id", "StudentID", partyListMember.StudentID);
            return View(partyListMember);
        }

        // GET: PartyListMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            var student = from x in db.Students
                          where x.StudentID == id
                          orderby x.StudentID
                          select new
                          {
                              ID = x.StudentID,
                              Name = x.StudentSchoolID + " " + x.LastName + ", " + x.FirstName
                          };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartyListMember partyListMember = db.PartyListMembers.Find(id);
            if (partyListMember == null)
            {
                return HttpNotFound();
            }
            ViewBag.students = db.Students.Find(id);
            ViewBag.PartyListID = new SelectList(db.PartyLists.Where(x => x.isEnable == true), "PartyListID", "PartyListName");
            ViewBag.StudentID = new SelectList(student, "ID", "Name");
            return View(partyListMember);
        }

        // POST: PartyListMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PartyListID,StudentID,isOfficer")] PartyListMember partyListMember)
        {
            if (ModelState.IsValid)
            {
                var data = partyListMember;
                db.Entry(partyListMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Students");
            }
            ViewBag.PartyListID = new SelectList(db.PartyLists.Where(x => x.isEnable == true), "PartyListID", "PartyListName", partyListMember.PartyListID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentID", partyListMember.StudentID);
            return View(partyListMember);
        }

        // GET: PartyListMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartyListMember partyListMember = db.PartyListMembers.Find(id);
            if (partyListMember == null)
            {
                return HttpNotFound();
            }
            return View(partyListMember);
        }

        // POST: PartyListMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PartyListMember partyListMember = db.PartyListMembers.Find(id);
            db.PartyListMembers.Remove(partyListMember);
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
