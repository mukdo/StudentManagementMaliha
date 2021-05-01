using StudentManagementTest.Library.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementTest.Web.Areas.Admin.Models.Course
{
    public class EditCourseModel : CourseBaseModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int SeatCount { get; set; }
        [Required]
        public int Fee { get; set; }

        public EditCourseModel(ICourseService courseService) : base( courseService) { }
        public EditCourseModel() : base() { }

        public void EditCourse()
        {
            var editCourse = new StudentManagementTest.Library.Entity.Course()
            {
                Id = this.Id,
                Title = this.Title,
                SeatCount = this.SeatCount,
                Fee = this.Fee
            };
            _courseService.EditCourse(editCourse);
        }

        internal void Load(int id)
        {
            var course = _courseService.GetCourse(id);
            if(course != null)
            {
                Id = course.Id;
                Title = course.Title;
                SeatCount = course.SeatCount;
                Fee = course.Fee;
            }
        }
        
    }
}
