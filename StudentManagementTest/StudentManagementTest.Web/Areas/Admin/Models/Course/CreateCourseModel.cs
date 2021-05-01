using StudentManagementTest.Library.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementTest.Web.Areas.Admin.Models.Course
{
    public class CreateCourseModel : CourseBaseModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int SeatCount { get; set; }
        [Required]
        public int Fee { get; set; }

        public CreateCourseModel(ICourseService courseService) : base(courseService) { }
        public CreateCourseModel() : base() { }

        public void Create()
        {
            var course = new StudentManagementTest.Library.Entity.Course()
            {
                Title = this.Title,
                SeatCount = this.SeatCount,
                Fee = this.Fee
            };
            _courseService.AddCourse(course);
        }

    }
}
