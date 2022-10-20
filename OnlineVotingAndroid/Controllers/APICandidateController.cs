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
    public class APICandidateController : ApiController
    {
        private OnlineVotingDbContext db = new OnlineVotingDbContext();

        // GET: api/APICandidate
        public IQueryable<Candidate> GetCandidates()
        {
            return db.Candidates;
        }

        [Route("api/GetCandidateList")]
        public IHttpActionResult GetCandidateList(int StudentID)
        {
            var student = db.Students.Find(StudentID);

            var candidates = db.Candidates.Include(c => c.Position).Where(c => c.Position.Election.IsActive == true).Include(c => c.Students).ToList();

            var filteredCan = from x in candidates
                              where x.Position.Representative == true && x.Students.YearAndSectionID != student.YearAndSectionID
                              select x;
            candidates.Remove((Candidate)filteredCan);

            var listCandidates = from c in filteredCan
                                 join ptl in db.PartyListMembers on c.StudentID equals ptl.StudentID into table1
                                 from tbl in table1.DefaultIfEmpty()
                                 select new
                                 {
                                     CandidateID = c.CandidateID,
                                     StudentID = c.StudentID,
                                     FirstName = c.Students.FirstName,
                                     LastName = c.Students.LastName,
                                     PartyListName = tbl == null || tbl.PartyLists.PartyListName == null ? "N/A" : tbl.PartyLists.PartyListName,
                                     checkboxValue = false,
                                     positionID = c.PositionId
                                 };

            return Ok(listCandidates.ToList());
        }

        [Route("api/GetPositions")]
        public IHttpActionResult GetPositions()
        {
            var positions = db.Positions.Where(x => x.Election.IsActive == true).ToList();

            return Ok(positions);
        }

        // GET: api/APICandidate/5
        [ResponseType(typeof(Candidate))]
        public IHttpActionResult GetCandidate(int id)
        {
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return NotFound();
            }

            return Ok(candidate);
        }

        // PUT: api/APICandidate/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCandidate(int id, Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidate.CandidateID)
            {
                return BadRequest();
            }

            db.Entry(candidate).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExists(id))
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

        // POST: api/APICandidate
        [ResponseType(typeof(Candidate))]
        public IHttpActionResult PostCandidate(Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Candidates.Add(candidate);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = candidate.CandidateID }, candidate);
        }

        // DELETE: api/APICandidate/5
        [ResponseType(typeof(Candidate))]
        public IHttpActionResult DeleteCandidate(int id)
        {
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return NotFound();
            }

            db.Candidates.Remove(candidate);
            db.SaveChanges();

            return Ok(candidate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CandidateExists(int id)
        {
            return db.Candidates.Count(e => e.CandidateID == id) > 0;
        }
    }
}