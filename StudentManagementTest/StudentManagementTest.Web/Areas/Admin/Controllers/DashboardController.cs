using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagementTest.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentManagementTest.Framework;

namespace StudentManagementTest.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Administrator")]
    public class DashboardController : Controller
    {
        private SMDbContext _sMDbContext;
        public DashboardController(SMDbContext sMDbContext)
        {
            _sMDbContext = sMDbContext;
        }
        public IActionResult Index()
        {
            ViewBag.countStudent = _sMDbContext.Students.Count();
            ViewBag.countCourse = _sMDbContext.Courses.Count();
           // ViewBag.countStudentRegistration = _sMDbContext.StudentRegistrations.Count();
            var model = new DashBoardModel();
            
            return View(model);

        } 
    }
}