using MVCDemo.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class CourseController : Controller
    {
        MContext s_context = new MContext();
        // GET: Course
        public ActionResult Index(string SearchName)
        {

            var courses = from c in s_context.DbSetCourses
                          select c;

            if (!String.IsNullOrEmpty(SearchName))
            {
                courses = courses.Where(s => s.Name.Contains(SearchName));
            }

            return View(courses);
        }

        //View to create a new course
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //Posting the new course to DB
        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                int rnd = new Random().Next(4001, 4999);
                while (CourseNumberAlreadyExists(rnd))
                {
                    rnd = new Random().Next(4001, 4999);
                    if (CourseNumberAlreadyExists(rnd))
                        continue;
                    else
                        break;
                }
                if (!CourseNumberAlreadyExists(rnd))
                {
                    s_context.DbSetCourses.Add(
                        new Course
                        {
                            CourseNumber = rnd,
                            Name = course.Name,
                            Capacity = course.Capacity,


                        });
                }
                //else
                //{
                //    s_context.DbSetCourses.Add(
                //        new Course
                //        {
                //            CourseNumber = new Random().Next(rnd, 4999),
                //            Name = course.Name,
                //            Capacity = course.Capacity
                //        });
                //}

                s_context.SaveChanges();


                //MContext s_context = new MContext();
                //var c = s_context.DbSetCourses.SingleOrDefault(k => k.CourseID == id);
                //s_context.DbSetCourses.Add(course);
                //s_context.SaveChanges();

                return RedirectToAction("Index", "Course");
            }
            else
            {
                return View();
            }

        }

        //Checks whether a random course number generated is present already or not
        private bool CourseNumberAlreadyExists(int rnd)
        {
            return s_context.DbSetCourses.Any(cn => cn.CourseNumber != rnd);
        }

        //View to edit the course
        [HttpGet]
        public ActionResult Edit(int id)
        {
            MContext s_context = new MContext();
            var EditCourse = s_context.DbSetCourses.Where(i => i.CourseID == id).FirstOrDefault();
            return View(EditCourse);
        }

        //Post the edited course changes to DB
        [HttpPost]
        public ActionResult Edit(Course course, int id)
        {
            Course c;
            if (ModelState.IsValid)
            {
                //This is to get the record from the context
                using (MContext s_context = new MContext())
                {
                    c = s_context.DbSetCourses.Where(i => i.CourseID == id).FirstOrDefault();
                }
                if (c != null)
                {
                    c.Name = course.Name;
                    c.Capacity = course.Capacity;

                }

                //Updating in the DB
                using (MContext sDB_context = new MContext())
                {
                    sDB_context.Entry(c).State = System.Data.Entity.EntityState.Modified;
                    sDB_context.SaveChanges();
                }
                return RedirectToActionPermanent("Index", "Course");
            }
            else
            {
                return View();
            }

        }

        //Get details of the course
        public ActionResult Details(int id)
        {
            var CourseDetails = s_context.DbSetCourses.Single(s => s.CourseID == id);

            return View(CourseDetails);
        }

        //View to delete a course
        public ActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //var course = s_context.DbSetCourses.Find(id);
            //if (course != null)
            //{
            //    return View(course);
            //}
            //else
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        //Confirmed delete a course
        public ActionResult DeleteConfirmed(bool confirm,int id)
        {
            if (confirm)
            {
                MContext s_context = new MContext();
                var DeleteCourse = s_context.DbSetCourses.Find(id);
                s_context.DbSetCourses.Remove(DeleteCourse);
                s_context.SaveChanges();

                return RedirectToAction("Index", "Course");

            }
            else
            {
                return HttpNotFound();
            }//return Json(JsonRequestBehavior.DenyGet);
        }









        //public ActionResult CList()
        //{
        //    MContext s = new MContext();
        //    return View(s.DbSetCourses.ToList());

        //}

        //[HttpPost]
        //public ActionResult Enroll(int id)
        //{
        //    MContext s_context = new MContext();
        //    var stu=s_context.DbSetStudents.Where(i => i.StudentID == id).FirstOrDefault();
        //    //s_context.DbSetCourses.Where(l => l.StudentList.Any(i => i.StudentID != id));
                
        //    return View();
        //}
    }
}