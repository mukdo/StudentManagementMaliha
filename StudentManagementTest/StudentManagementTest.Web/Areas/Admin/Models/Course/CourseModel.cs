using StudentManagementTest.Library.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementTest.Web.Areas.Admin.Models.Course
{
    public class CourseModel : CourseBaseModel
    {
        public CourseModel(ICourseService courseService) : base( courseService) { }
        public CourseModel() : base() { }

        internal object GetCourse(DataTablesAjaxRequestModel dataTables)
        {
            var data = _courseService.GetCourses(
                                  dataTables.PageIndex,
                                   dataTables.PageSize,
                                  dataTables.SearchText,
                                  dataTables.GetSortText(new string[] { "Id", "Title", "SeatCount", "Fee" }));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.courses
                        select new string[]
                        {
                                record.Title,
                                record.SeatCount.ToString(),
                                record.Fee.ToString(),
                                record.Id.ToString()
    }
                   ).ToArray()

            };
        }
        internal string Delete(int Id)
        {
            var deleteCourse = _courseService.DeleteCourse(Id);
            return deleteCourse.Title;

        }
    }
}
