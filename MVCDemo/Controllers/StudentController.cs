using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        //public ActionResult Index()
        //{
        //    MContext s_context = new MContext();
        //    var ListOfStudents = s_context.DbSetStudents.ToList();
        //    return View(ListOfStudents);
        //}


        //Get method for both index and search
        public ActionResult Index(string SearchName)
        {
            MContext s_context = new MContext();
            var students = from s in s_context.DbSetStudents
                           //group s.EnrollmentNumber 
                           select s;

            if (!String.IsNullOrEmpty(SearchName))
            {
                students = students.Where(s => s.Name.StartsWith(SearchName));
            }

            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            MContext s_context = new MContext();
            var EnrollDetails = s_context
                                .DbSetEnrollments
                                .FirstOrDefault(s => s.student.StudentID== id);
            var StudentDetails = s_context
                                .DbSetStudents
                                .FirstOrDefault(s => s.StudentID == id);
            //var CourseDetails = s_context
            //                    .DbSetCourses
            //                    .All(a=>a.StudentID == id);

            //dynamic model = new ExpandoObject();
            //model.Students = StudentDetails;
            //model.Enrolls = EnrollDetails;

            return View(StudentDetails);
        }

        // GET: Student/Create
        [HttpGet]
        public ActionResult Create()
        {
            //MContext s_context = new MContext();
            //var CourseList = s_context.DbSetCourses.ToList();

            //return View(CourseList);
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                // TODO: Add insert logic here
                MContext s_context = new MContext();
                s_context.DbSetStudents.Add(
                new Student
                {
                    Name = student.Name,
                    Address = student.Address,
                    Contact = student.Contact,
                    DateOfBirth = student.DateOfBirth,
                    EnrollmentNumber = new Random().Next(100001, 199999)

                });


                s_context.SaveChanges();

                return RedirectToAction("Index", "Student");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            MContext s_context = new MContext();
            var StudentDetails = s_context.DbSetStudents.SingleOrDefault(s => s.StudentID == id);

            return View(StudentDetails);
        }

        // POST: Student/Edit/5
        //The Bind attribute is another important security mechanism 
        //that keeps hackers from over-posting data to your model. 
        //You should only include properties in the bind attribute that you want to change. 
        [HttpPost]
        public ActionResult Edit([Bind(Include = "EnrollmentNumber,Name,Address,Contact,DateOfBirth")] Student student, int id)
        {
            if (ModelState.IsValid)
            {
                Student stu;
                // TODO: Add update logic here
                using (MContext s_context = new MContext())
                {
                    stu = s_context.DbSetStudents.Where(s => s.StudentID == id).FirstOrDefault<Student>();
                }

                if (stu != null)
                {
                    stu.EnrollmentNumber = student.EnrollmentNumber;
                    stu.Name = student.Name;
                    stu.Address = student.Address;
                    stu.Contact = student.Contact;
                    stu.DateOfBirth = student.DateOfBirth;
                }

                using (MContext sDB_context = new MContext())
                {
                    sDB_context.Entry(stu).State = EntityState.Modified;
                    sDB_context.SaveChanges();
                }
                return RedirectToAction("Index", "Student");

            }
            else
            {
                return RedirectToAction("Index", "Student");
            }
        }

        // GET: Student/Delete/5
        //public ActionResult Delete()
        //{
        //    //MContext s_context = new MContext();

        //    //var DelStu = s_context.DbSetStudents.SingleOrDefault(x => x.StudentID == id);
        //    //s_context.DbSetStudents.Remove(DelStu);
        //    //s_context.SaveChanges();

        //    return RedirectToAction("Index", "Student");
        //}

        //// POST: Student/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here
        //        MContext s_context = new MContext();

        //        var DelStu = s_context.DbSetStudents.SingleOrDefault(x => x.StudentID == id);
        //        s_context.DbSetStudents.Remove(DelStu);
        //        s_context.SaveChanges();

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        public ActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //MContext s_context = new MContext();

            //var stu = s_context.DbSetStudents.Find(id);

            //if (stu == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(stu);
            return View();
        }


       // [HttpPost]
        public ActionResult DeleteConfirmed(bool confirm,int id)
        {
            if (confirm)  
            {
                MContext s_context = new MContext();

                var stu = s_context.DbSetStudents.Find(id);
                s_context.DbSetStudents.Remove(stu);
                s_context.SaveChanges();

                return RedirectToAction("Index", "Student");
                //return true;
                //return new HttpStatusCodeResult(HttpStatusCode.OK);
                //return Json(JsonRequestBehavior.DenyGet);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public JsonResult GetStudents(string term)
        {
            MContext s_context = new MContext();
            List<string> students;
            //if (string.IsNullOrEmpty(term))
            //{
            //    students = s_context.DbSetStudents.ToList();
            //}
            //else
            
                students = s_context
                          .DbSetStudents
                          .Where(x => x.Name.StartsWith(term))
                          .Select(y=>y.Name)
                          .ToList();
            

            return Json(students,JsonRequestBehavior.AllowGet);

        }


    }
}
