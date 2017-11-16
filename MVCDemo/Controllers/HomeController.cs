using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //MContext s_context = new MContext();

            //var c= s_context.DbSetCourses.Add(
            //    new Course { Capacity = 100, CourseID = 10254, Name = "Programming" });

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}