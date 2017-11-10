using MVCDemo.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            StudentContext s_context = new StudentContext();
            var c=s_context.DbSetCourses.ToList();
            return View(c);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                StudentContext s_context = new StudentContext();
                
                int rnd = new Random().Next(4001, 4999);
                if (s_context.DbSetCourses.Any(cn => cn.CourseNumber != rnd))
                {
                    s_context.DbSetCourses.Add(
                        new Course
                        {
                          CourseNumber = rnd,
                          Name =course.Name,
                          Capacity=course.Capacity,
                          
                          
                        });
                }
                else
                {
                    s_context.DbSetCourses.Add(
                        new Course
                        {
                            CourseNumber = new Random().Next(rnd, 4999),
                            Name = course.Name,
                            Capacity = course.Capacity
                        });
                }
                
                s_context.SaveChanges();
                
                
                //StudentContext s_context = new StudentContext();
                //var c = s_context.DbSetCourses.SingleOrDefault(k => k.CourseID == id);
                //s_context.DbSetCourses.Add(course);
                //s_context.SaveChanges();

                return RedirectToAction("Index","Course");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            StudentContext s_context = new StudentContext();
            var EditCourse = s_context.DbSetCourses.Where(i => i.CourseID == id).FirstOrDefault();
            return View(EditCourse);
        }


        [HttpPost]
        public ActionResult Edit(Course course, int id)
        {
            Course c;
            if (ModelState.IsValid)
            {
                //This is to get the record from the context
                using (StudentContext s_context = new StudentContext())
                {
                    c = s_context.DbSetCourses.Where(i => i.CourseID == id).FirstOrDefault();
                }
                if (c != null)
                {
                    c.Name = course.Name;
                    c.Capacity = course.Capacity;

                }

                //Updating in the DB
                using (StudentContext sDB_context = new StudentContext())
                {
                    sDB_context.Entry(c).State=System.Data.Entity.EntityState.Modified;
                    sDB_context.SaveChanges();
                }
                return RedirectToActionPermanent("Index", "Course");
            }
            else
            {
                return View();
            }

        }


        public ActionResult Details(int id)
        {
            StudentContext s_context = new StudentContext();
           var CourseDetails= s_context.DbSetCourses.Single(s => s.CourseID == id);

            return View(CourseDetails);
        }

        public ActionResult Delete(int id)
        {
            StudentContext s_context = new StudentContext();
            var DeleteCourse = s_context.DbSetCourses.Single(s => s.CourseID == id);
            s_context.DbSetCourses.Remove(DeleteCourse);
            s_context.SaveChanges();

            return RedirectToAction("Index","Course");
        }




        public ActionResult CList()
        {
            StudentContext s = new StudentContext();
            return View(s.DbSetCourses.ToList());

        }

        [HttpPost]
        public ActionResult Enroll(int id)
        {
            StudentContext s_context = new StudentContext();
            var stu=s_context.DbSetStudents.Where(i => i.StudentID == id).FirstOrDefault();
            //s_context.DbSetCourses.Where(l => l.StudentList.Any(i => i.StudentID != id));
                
            return View();
        }
    }
}