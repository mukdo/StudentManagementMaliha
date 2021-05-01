using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StudentManagementTest.Framework;
using StudentManagementTest.Web.Areas.Admin.Models;
using StudentManagementTest.Web.Areas.Admin.Models.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementTest.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Administrator")]
    public class CourseController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<CourseModel> _logger;

        public CourseController(IConfiguration configuration, ILogger<CourseModel> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<CourseModel>();
            return View(model);
        }

        public IActionResult CreateCourse()
        {
            var model = new CreateCourseModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCourse([Bind(nameof(CreateCourseModel.Title),
                                                nameof(CreateCourseModel.SeatCount),
                                                nameof(CreateCourseModel.Fee))]
                                            CreateCourseModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                    model.Response = new ResponseModel("Add a new Course Successful", ResponseType.Success);

                    //logger code
                    _logger.LogInformation("Course Create Sucessfully");

                    return RedirectToAction("Index");
                }

                catch (DuplicationException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                    _logger.LogError("Course Title already Exist");
                }

                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Course Add failued.", ResponseType.Failure);
                    _logger.LogError($"Course Add 'Failed'. Excption is : {ex.Message}");
                }
            }

            return View(model);
        }

        public IActionResult EditCourse(int id)
        {
            var model = new EditCourseModel();
            model.Load(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCourse([Bind(nameof(EditCourseModel.Id),
                                                nameof(EditCourseModel.Title),
                                                nameof(EditCourseModel.SeatCount),
                                                nameof(EditCourseModel.Fee))]
                                            EditCourseModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.EditCourse();
                    model.Response = new ResponseModel("Course editing successful.", ResponseType.Success);

                    //logger code
                    _logger.LogInformation("Course Edit Successful");

                    return RedirectToAction("Index");

                }

                catch (DuplicationException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                    _logger.LogError("Course Title already Exist");
                }

                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Course Edit Failued.", ResponseType.Failure);
                    // error logger code
                    _logger.LogError($"Course Edit 'Failed'. Excption is : {ex.Message}");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCourse(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new CourseModel();
                try
                {
                    var provider = model.Delete(id);
                    model.Response = new ResponseModel($"Course {provider} successfully deleted.", ResponseType.Success);
                    return RedirectToAction("Index");
                }

                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Course Delete failed.", ResponseType.Failure);
                    // error logger code
                    _logger.LogError($"Course Delete 'Failed'. Excption is : {ex.Message}");
                }
            }
            return RedirectToAction("index");
        }


        public IActionResult GetCourse()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<CourseModel>();
            var data = model.GetCourse(tableModel);
            return Json(data);
        }


    }
}
