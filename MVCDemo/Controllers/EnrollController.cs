using MVCDemo.Models;
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

            MContext s_context = new MContext();
            var CourseList = s_context.DbSetCourses.ToList();
            SelectList list = new SelectList(CourseList,"CourseID","Name");
            ViewBag.CList = list;

           // var s=s_context.DbSetStudents.FirstOrDefault(i => i.StudentID == id);

            return View();
        }

        [HttpPost]
        public ActionResult Enroll(int sID,int cID)
        {

            return View();
        }
    }
}