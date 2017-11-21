using MVCDemo.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class EnrollController : Controller
    {
        // GET: Enroll
        [HttpGet]
        public ActionResult Enroll ()
        {

           // MContext s_context = new MContext();
           // var CourseList = s_context.DbSetCourses.ToList();
           // SelectList list = new SelectList(CourseList,"CourseID","Name");
           // ViewBag.CList = list;

           //var s=s_context.DbSetEnrollments.FirstOrDefault(i => i.student.StudentID == id);

            return View();
        }

        [HttpPost]
        public ActionResult Enroll(FormCollection enroll)
        {
            MContext s_context = new MContext();
            var t = Convert.ToInt32(Request.Form["Course Number"]);
            var u = Convert.ToInt32(Request.Form["Enrollement Number"]);
            
            var s = s_context.DbSetStudents.First(x=>x.StudentID == u);
            var c = s_context.DbSetCourses.First(x => x.CourseNumber == t);

            s_context.DbSetEnrollments.Add(
                new Enrollment
                {
                    CourseID=c.CourseID,
                    StudentID=s.StudentID

                });
            
            s_context.SaveChanges();
            return RedirectToAction("Index","Student");
        }
    }
}