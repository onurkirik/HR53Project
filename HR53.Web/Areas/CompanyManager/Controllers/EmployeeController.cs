﻿using Microsoft.AspNetCore.Mvc;

namespace HR53.Web.Areas.CompanyManager.Controllers
{
    
    [Area("CompanyManager")]
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}