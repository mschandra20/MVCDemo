﻿using MVCDemo.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class EnrollController : Controller
    {
        // GET: Enroll
        [HttpGet]
        public ActionResult Enroll(FormCollection enroll)
        {
            //Course Name List
            MContext s_context = new MContext();
            //var CourseNameList = s_context.DbSetCourses.ToList();
            //SelectList CNamelist = new SelectList(CourseNameList, "CourseID", "Name");
            //ViewBag.CList = CNamelist;

            //Course Number List
            var CourseNumberList = s_context.DbSetCourses.ToList();
            SelectList CNumlist = new SelectList(CourseNumberList, "CourseID", "CourseNumber");
            ViewBag.CNList = CNumlist;

            //var s = s_context.DbSetEnrollments.FirstOrDefault(i => i.student.StudentID == id);

            //Student Name List
            //var StudentNameList = s_context.DbSetStudents.ToList();
            //SelectList SNamelist = new SelectList(StudentNameList, "StudentID", "Name");
            //ViewBag.SList = SNamelist;

            //Student Number List
            var StudentNumberList = s_context.DbSetStudents.ToList();
            SelectList SNumlist = new SelectList(StudentNumberList, "StudentID", "EnrollmentNumber");
            ViewBag.SNList = SNumlist;

            ////////////////////////////////////////////////////////////////////////////////////////

            var sn = Convert.ToInt32(Request.Form["Enrollment Number"]);
            var s = GetStudent(sn);
            Enrollment e = new Enrollment();
            e.student = s;
            return View(e);
        }

        [HttpPost]
        [ActionName("Enroll")]
        public ActionResult Enroll_post(FormCollection enroll)
        {
            MContext s_context = new MContext();
            //Here we get the id of the student and course and we associate 
            //them with the enrollment object

            var st = Convert.ToInt32(Request.Form[0]);//Student

            var co = Convert.ToInt32(Request.Form[1]);//Course


            var c = s_context.DbSetCourses.SingleOrDefault(x => x.CourseID == co);
            var s = s_context.DbSetStudents.SingleOrDefault(x => x.StudentID== st);

            if (c != null )
            {
            RedirectToAction("Enroll", "Enroll");


            }

            if (s != null)
            {
                RedirectToAction("Enroll", "Enroll");

            }


            s_context.DbSetEnrollments.Add(
                new Enrollment
                {
                    CourseID = co,
                    StudentID = st

                });

            s_context.SaveChanges();
            return RedirectToAction("Index", "Student");
        }






        public Student GetStudent(int sn)
        {
            MContext s_context = new MContext();
           // var sn  = Convert.ToInt32(Request.Form["Enrollment Number"]);
            var sobj = s_context.DbSetStudents.FirstOrDefault(x => x.EnrollmentNumber == sn);
            //var sid = sobj.StudentID;


            return sobj;
        }


    }
}