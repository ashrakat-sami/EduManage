﻿using Microsoft.AspNetCore.Mvc;

namespace EduManage.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
