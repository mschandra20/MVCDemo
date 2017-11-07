using MVCDemo.Models;
using System;
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
                    EnrollmentID= new Random().Next(100001, 199999)

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
        public ActionResult Edit([Bind(Include = "StudentID,Name,Address,Contact,DateOfBirth")] Student student)
        {
            try
            {
                // TODO: Add update logic here
                StudentContext s_context = new StudentContext();
                
                s_context.Entry(student).State=System.Data.Entity.EntityState.Modified;
                s_context.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            StudentContext s_context = new StudentContext();

            var DelStu = s_context.DbSetStudents.SingleOrDefault(x => x.StudentID == id);
            s_context.DbSetStudents.Remove(DelStu);
            s_context.SaveChanges();

            return RedirectToAction("Index","Student");
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
    }
}
