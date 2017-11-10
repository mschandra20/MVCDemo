using MVCDemo.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
namespace MVCDemo.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentContext s_context = new StudentContext();
            var ListOfStudents = s_context.DbSetStudents.ToList();

            return View(ListOfStudents);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            StudentContext s_context = new StudentContext();
            var StudentDetails = s_context.DbSetStudents.SingleOrDefault(s => s.StudentID == id);

            return View(StudentDetails);
        }

        // GET: Student/Create
        [HttpGet]
        public ActionResult Create()
        {
            //StudentContext s_context = new StudentContext();
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
                StudentContext s_context = new StudentContext();
                s_context.DbSetStudents.Add(
                new Student
                {
                    Name = student.Name,
                    Address = student.Address,
                    Contact = student.Contact,
                    DateOfBirth = student.DateOfBirth,
                    EnrollmentID = new Random().Next(100001, 199999)

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
            StudentContext s_context = new StudentContext();
            var StudentDetails = s_context.DbSetStudents.SingleOrDefault(s => s.StudentID == id);

            return View(StudentDetails);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "EnrollmentID,Name,Address,Contact,DateOfBirth")] Student student, int id)
        {
            if (ModelState.IsValid)
            {
                Student stu;
                // TODO: Add update logic here
                using (StudentContext s_context = new StudentContext())
                {
                    stu = s_context.DbSetStudents.Where(s => s.StudentID == id).FirstOrDefault<Student>();
                }

                if (stu != null)
                {
                    stu.EnrollmentID = student.EnrollmentID;
                    stu.Name = student.Name;
                    stu.Address = student.Address;
                    stu.Contact = student.Contact;
                    stu.DateOfBirth = student.DateOfBirth;
                }

                using (StudentContext sDB_context = new StudentContext())
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
        public ActionResult Delete(int id)
        {
            StudentContext s_context = new StudentContext();

            var DelStu = s_context.DbSetStudents.SingleOrDefault(x => x.StudentID == id);
            s_context.DbSetStudents.Remove(DelStu);
            s_context.SaveChanges();

            return RedirectToAction("Index", "Student");
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        [HttpGet]
        public ActionResult Enroll(int id)
        {
            StudentContext s_context = new StudentContext();
            var EnrollStudent= s_context.DbSetStudents.SingleOrDefault(i => i.StudentID == id);

            return  RedirectToAction("CList","Course",EnrollStudent);
            
        }

        
    }
}
