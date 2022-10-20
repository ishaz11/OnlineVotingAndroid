using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using OnlineVotingAndroid.Models;

namespace OnlineVotingAndroid.Controllers
{
    public class PartyLists1Controller : ApiController
    {
        private OnlineVotingDbContext db = new OnlineVotingDbContext();

        // GET: api/PartyLists1
        public IQueryable<PartyList> GetPartyLists()
        {
            return db.PartyLists;
        }

        // GET: api/PartyLists1/5
        [ResponseType(typeof(PartyList))]
        public IHttpActionResult GetPartyList(int id)
        {
            PartyList partyList = db.PartyLists.Find(id);
            if (partyList == null)
            {
                return NotFound();
            }

            return Ok(partyList);
        }

        // PUT: api/PartyLists1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPartyList(int id, PartyList partyList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partyList.PartyListID)
            {
                return BadRequest();
            }

            db.Entry(partyList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartyListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PartyLists1
        [ResponseType(typeof(PartyList))]
        public IHttpActionResult PostPartyList(PartyList partyList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PartyLists.Add(partyList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = partyList.PartyListID }, partyList);
        }

        // DELETE: api/PartyLists1/5
        [ResponseType(typeof(PartyList))]
        public IHttpActionResult DeletePartyList(int id)
        {
            PartyList partyList = db.PartyLists.Find(id);
            if (partyList == null)
            {
                return NotFound();
            }

            db.PartyLists.Remove(partyList);
            db.SaveChanges();

            return Ok(partyList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PartyListExists(int id)
        {
            return db.PartyLists.Count(e => e.PartyListID == id) > 0;
        }
    }
}