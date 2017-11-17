using MVCDemo.Models;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class EnrollController : Controller
    {
        // GET: Enroll
        [HttpGet]
        public ActionResult Enroll (int id)
        {

           // MContext s_context = new MContext();
           // var CourseList = s_context.DbSetCourses.ToList();
           // SelectList list = new SelectList(CourseList,"CourseID","Name");
           // ViewBag.CList = list;

           //var s=s_context.DbSetEnrollments.FirstOrDefault(i => i.student.StudentID == id);

            return View();
        }

        [HttpPost]
        public ActionResult Enroll(Enrollment enroll)
        {
            MContext s_context = new MContext();
            s_context.DbSetEnrollments.Add(
                new Enrollment
                {
                    CourseID=enroll.CourseID,
                    StudentID=enroll.StudentID

                });
            return RedirectToAction("Index","Student");
        }
    }
}