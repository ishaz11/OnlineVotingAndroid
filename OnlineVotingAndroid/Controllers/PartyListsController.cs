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
    public class PartyListsController : Controller
    {
        private OnlineVotingDbContext db = new OnlineVotingDbContext();

        // GET: PartyLists
        public ActionResult Index()
        {
            return View(db.PartyLists.ToList());
        }

        // GET: PartyLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartyList partyList = db.PartyLists.Find(id);
            if (partyList == null)
            {
                return HttpNotFound();
            }
            return View(partyList);
        }

        // GET: PartyLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PartyLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PartyListID,PartyListName,IsActive,isEnable")] PartyList partyList)
        {
            partyList.isEnable = true;
            partyList.IsActive = true;
            if (ModelState.IsValid)
            {
                db.PartyLists.Add(partyList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partyList);
        }

        // GET: PartyLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartyList partyList = db.PartyLists.Find(id);
            if (partyList == null)
            {
                return HttpNotFound();
            }
            return View(partyList);
        }

        // POST: PartyLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PartyListID,PartyListName,IsActive,isEnable")] PartyList partyList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partyList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partyList);
        }

        // GET: PartyLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartyList partyList = db.PartyLists.Find(id);
            if (partyList == null)
            {
                return HttpNotFound();
            }
            return View(partyList);
        }

        // POST: PartyLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PartyList partyList = db.PartyLists.Find(id);
            db.PartyLists.Remove(partyList);
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
