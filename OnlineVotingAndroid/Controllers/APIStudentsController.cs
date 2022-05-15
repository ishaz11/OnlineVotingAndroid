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
using OnlineVotingAndroid.Models.APIModels;

namespace OnlineVotingAndroid.Controllers
{
    public class APIStudentsController : ApiController
    {
        private OnlineVotingDbContext db = new OnlineVotingDbContext();

        // GET: api/APIStudents
        public IQueryable<Students> GetStudents()
        {
            return db.Students;
        }

        [Route("api/StudentLogin")]
        public IHttpActionResult StudentLogin(Students students)
        {
            students = db.Students.Where(x => x.StudentSchoolID == students.StudentSchoolID && x.Password   == students.Password).FirstOrDefault();
            if (students == null)
            {
                return NotFound();
            }

            return Ok(students);
        }

        [Route("api/ChangePassword")]
        public IHttpActionResult ChangePassword(_StudentChangePass _changePass)
        {
            var students = db.Students.Where(x => x.StudentSchoolID == _changePass.StudentSchoolID && x.Password == _changePass.Password).FirstOrDefault();
            students.Password = _changePass.NewPassword;
            db.SaveChanges();
            if (students == null)
            {
                return NotFound();
            }

            return Ok(students);
        }

        // GET: api/APIStudents/5
        [ResponseType(typeof(Students))]
        public IHttpActionResult GetStudents(int id)
        {
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return NotFound();
            }

            return Ok(students);
        }

        // PUT: api/APIStudents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudents(int id, Students students)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != students.StudentID)
            {
                return BadRequest();
            }

            db.Entry(students).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsExists(id))
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

        // POST: api/APIStudents
        [ResponseType(typeof(Students))]
        public IHttpActionResult PostStudents(Students students)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(students);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = students.StudentID }, students);
        }

        // DELETE: api/APIStudents/5
        [ResponseType(typeof(Students))]
        public IHttpActionResult DeleteStudents(int id)
        {
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return NotFound();
            }

            db.Students.Remove(students);
            db.SaveChanges();

            return Ok(students);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentsExists(int id)
        {
            return db.Students.Count(e => e.StudentID == id) > 0;
        }
    }
}