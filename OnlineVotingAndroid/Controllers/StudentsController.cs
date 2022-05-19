using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineVotingAndroid.Models;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace OnlineVotingAndroid.Controllers
{
    public class StudentsController : Controller
    {
        private OnlineVotingDbContext db = new OnlineVotingDbContext();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.ToList();
            var partylistMember = db.PartyListMembers.ToList();
            var partylist = db.PartyLists.ToList();

            var studentsAndparty = from s in students where s.isEnable == true
                                   join ptm in partylistMember.Where(x=> x.PartyLists.isEnable == true) on s.StudentID equals ptm.StudentID into table1
                                   from tbl in table1.DefaultIfEmpty()
                                   select new StudentsAndParty
                                   {
                                       students = s,
                                       party = tbl == null || tbl.PartyLists.PartyListName == null ? "N/A" : tbl.PartyLists.PartyListName,
                                       partyMemberID = tbl == null || tbl.Id == 0 ? 0 : tbl.Id
                                   };
            return View(studentsAndparty);
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.YearAndSectionID = new SelectList(db._YearAndSections, "YearAndSectionID", "Grade");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Students students)
        {
            ViewBag.YearAndSectionID = new SelectList(db._YearAndSections, "YearAndSectionID", "Grade");
            students.isEnable = true;
            students.Password = "1234";
            if (ModelState.IsValid)
            {
                db.Students.Add(students);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(students);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.YearAndSectionID = new SelectList(db._YearAndSections, "YearAndSectionID", "Grade");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Students students)
        {
            ViewBag.YearAndSectionID = new SelectList(db._YearAndSections, "YearAndSectionID", "Grade");
            if (ModelState.IsValid)
            {
                students.isEnable = true;
                db.Entry(students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(students);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Students students = db.Students.Find(id);
            students.isEnable = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ImportStudent()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ImportStudent(HttpPostedFileBase excelfile)
        {
            if (excelfile.ContentLength == 0 || excelfile == null)
            {
                ViewBag.Error = "Please select a valid excel file";
                return View();
            }
            else
            {
                if (excelfile.FileName.EndsWith("csv"))
                {
                    string path = Server.MapPath("/Upload/" + excelfile.FileName);

                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    
                    excelfile.SaveAs(path);

                    List<Students> students = new List<Students>();
                    string csvData = System.IO.File.ReadAllText(path);
                    foreach (string row in csvData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            students.Add(new Students
                            {
                                StudentSchoolID = row.Split(',')[0],
                                FirstName = row.Split(',')[1],
                                LastName = row.Split(',')[2],
                                StudentID = Convert.ToInt32(row.Split(',')[3]),
                                isEnable = true,
                                Password = "1234",
                                Date = DateTime.Now,
                                YearAndSectionID = 1
                        });
                        }
                    }
                    foreach (var student in students)
                    {
                        db.Students.Add(student);
                        db.SaveChanges();
                    }


                    

                    //Excel.Application application = new Excel.Application();
                    //Excel.Workbook workbook = application.Workbooks.Open(path);
                    //Excel.Worksheet worksheet = workbook.ActiveSheet;
                    //Excel.Range range = worksheet.UsedRange;

                    
                    //for (int row = 2; row <= range.Rows.Count; row++)
                    //{
                    //    Students student = new Students();
                    //    student.StudentSchoolID = ((Excel.Range)range.Cells[row, 1]).Text;
                    //    student.FirstName = ((Excel.Range)range.Cells[row, 2]).Text;
                    //    student.LastName = ((Excel.Range)range.Cells[row, 3]).Text;
                    //    student.Date = DateTime.Now;
                    //    student.YearnSection = ((Excel.Range)range.Cells[row, 4]).Text;
                    //    students.Add(student);
                    //    db.Students.Add(student);
                    //    db.SaveChanges();
                    //}

                    return View();
                }
                else
                {
                    ViewBag.Error = "Something went wrong";
                    return View("Index");
                }
            }
        }

        //[HttpPost]
        //public ActionResult ImportStudent(HttpPostedFileBase excelfile)
        //{
        //    if (excelfile.ContentLength == 0 || excelfile == null)
        //    {
        //        ViewBag.Error = "Please select a valid excel file";
        //        return View();
        //    }
        //    else
        //    {
        //        if (excelfile.FileName.EndsWith("xls") || excelfile.FileName.EndsWith("xlsx"))
        //        {
        //            string path = Server.MapPath("/Upload/" + excelfile.FileName);

        //            if (System.IO.File.Exists(path))
        //            {
        //                System.IO.File.Delete(path);
        //            }
        //            excelfile.SaveAs(path);

        //            Excel.Application application = new Excel.Application();
        //            Excel.Workbook workbook = application.Workbooks.Open(path);
        //            Excel.Worksheet worksheet = workbook.ActiveSheet;
        //            Excel.Range range = worksheet.UsedRange;

        //            List<Students> students = new List<Students>();
        //            for (int row = 2; row <= range.Rows.Count; row++)
        //            {
        //                Students student = new Students();
        //                student.StudentSchoolID = ((Excel.Range)range.Cells[row, 1]).Text;
        //                student.FirstName = ((Excel.Range)range.Cells[row, 2]).Text;
        //                student.LastName = ((Excel.Range)range.Cells[row, 3]).Text;
        //                student.Date = DateTime.Now;
        //                student.YearnSection = ((Excel.Range)range.Cells[row, 4]).Text;
        //                students.Add(student);
        //                db.Students.Add(student);
        //                db.SaveChanges();
        //            }

        //            return View();
        //        }
        //        else
        //        {
        //            ViewBag.Error = "Something went wrong";
        //            return View("Index");
        //        }
        //    }
        //}

        public ActionResult SetStudent()
        {
            var students = db.Students.ToList();
            foreach (var student in students)
            {
                student.isEnable = true;
            }
            return View("Index");
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
