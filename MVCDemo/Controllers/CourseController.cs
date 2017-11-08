﻿using MVCDemo.Models;
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
                s_context.DbSetCourses.Add(new Course {CourseNumber=new Random().Next(4001,4999)});
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
    }
}