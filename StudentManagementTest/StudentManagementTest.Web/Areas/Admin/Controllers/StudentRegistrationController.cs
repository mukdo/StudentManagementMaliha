using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StudentManagementTest.Web.Areas.Admin.Models;
using StudentManagementTest.Web.Areas.Admin.Models.StudentRegistrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementTest.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
   // [Authorize(Roles = "SuperAdmin,Administrator")]
    public class StudentRegistrationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<StudentRegistrationModel> _logger;
        public StudentRegistrationController(IConfiguration configuration, ILogger<StudentRegistrationModel> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<StudentRegistrationModel>();
            return View(model);
        }

        public IActionResult CreateRegistration()
        {
            var model = new CreateRegistrationModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateRegistration([Bind (nameof(CreateRegistrationModel.StudentId),
                                               nameof(CreateRegistrationModel.CourseId),
                                               nameof(CreateRegistrationModel.EnrollDate),
                                               nameof(CreateRegistrationModel.IspaymentComplete))]
                                        CreateRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.AddRegistration();
                    model.Response = new ResponseModel("Student Register Successful", ResponseType.Success);

                    //logger code
                    _logger.LogInformation("Student Register Create Sucessfully");

                    return RedirectToAction("Index");
                }

                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Student Register failued.", ResponseType.Failure);
                    _logger.LogError($"Student Registe Create 'Failed'. Excption is : {ex.Message}");
                }
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = new EditRegistration();
            model.Load(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind (nameof(EditRegistration.Id),
                                               nameof(EditRegistration.StudentId),
                                               nameof(EditRegistration.CourseId),
                                               nameof(EditRegistration.EnrollDate),
                                               nameof(EditRegistration.IspaymentComplete))]
                                         EditRegistration model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Edit();
                    model.Response = new ResponseModel("Student Registration editing successful.", ResponseType.Success);

                    //logger code
                    _logger.LogInformation("Student Registration  Edit Successfully");

                    return RedirectToAction("Index");

                }

                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Student Registration  Edit failued.", ResponseType.Failure);
                    // error logger code
                    _logger.LogError($"Student Registration  Edit 'Failed'. Excption is : {ex.Message}");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteRegistration(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new StudentRegistrationModel();
                try
                {
                    var provider = model.Delete(id);
                    model.Response = new ResponseModel($"Registration {provider} successfully removed.", ResponseType.Success);
                    return RedirectToAction("Index");
                }

                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Registration removed failed.", ResponseType.Failure);
                    // error logger code
                    _logger.LogError($"Student Registration Delete 'Failed'. Excption is : {ex.Message}");
                }
            }
            return RedirectToAction("index");
        }


        public IActionResult GetRegistration()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<StudentRegistrationModel>();
            var data = model.GetStudentRegistration(tableModel);
            return Json(data);
        }

    }
}
