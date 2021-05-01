using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StudentManagementTest.Framework;
using StudentManagementTest.Web.Areas.Admin.Models;
using StudentManagementTest.Web.Areas.Admin.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementTest.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Administrator")]
    public class StudentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<StudentModel> _logger;

        public StudentController( IConfiguration configuration, ILogger<StudentModel> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<StudentModel>();
            return View(model);
        }

        public IActionResult CreateStudent()
        {
            var model = new AddStudentModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateStudent([Bind(nameof(AddStudentModel.Name),
                                                nameof(AddStudentModel.DateOfBirth))]
                                            AddStudentModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add();
                    model.Response = new ResponseModel("Add a new Student Successful", ResponseType.Success);

                    //logger code
                    _logger.LogInformation("Student Add Sucessfully");

                    return RedirectToAction("Index");
                }

                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Student Add failued.", ResponseType.Failure);
                    _logger.LogError($"Student Add 'Failed'. Excption is : {ex.Message}");
                }
            }

            return View(model);
        }

        public IActionResult EditStudent(int id)
        {
            var model = new EditStudentModel();
            model.Load(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditStudent([Bind(nameof(EditStudentModel.Id),
                                                nameof(EditStudentModel.Name),
                                                nameof(EditStudentModel.DateOfBirth))]
                                            EditStudentModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Edit();
                    model.Response = new ResponseModel("Student editing successful.", ResponseType.Success);

                    //logger code
                    _logger.LogInformation("Student Edit Successful");

                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Student Edit Failued.", ResponseType.Failure);
                    // error logger code
                    _logger.LogError($"Student Edit 'Failed'. Excption is : {ex.Message}");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteStudent(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new StudentModel();
                try
                {
                    var provider = model.Delete(id);
                    model.Response = new ResponseModel($"Student {provider} successfully deleted.", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Student Delete failed.", ResponseType.Failure);
                    // error logger code
                    _logger.LogError($"Student Delete 'Failed'. Excption is : {ex.Message}");
                }
            }
            return RedirectToAction("index");

        }


        public IActionResult GetStudent()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<StudentModel>();
            var data = model.GetStudent(tableModel);
            return Json(data);
        }
    }
}
