﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagementTest.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StudentManagementTest.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
  //  [Authorize(Roles = "SuperAdmin,Administrator")]
    public class DashboardController : Controller
    {
       
        public IActionResult Index()
        {
            
            var model = new DashBoardModel();
            return View(model);

        } 
    }
}