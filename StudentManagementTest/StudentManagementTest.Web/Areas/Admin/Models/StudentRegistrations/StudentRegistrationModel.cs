using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagementTest.Library.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementTest.Web.Areas.Admin.Models.StudentRegistrations
{
    public class StudentRegistrationModel : StudentRegitrationBaseModel
    {
        public StudentRegistrationModel(IStudentRegistrationService studentRegistrationService) : base(studentRegistrationService)
        {

        }

        public StudentRegistrationModel() : base() { }
       
        internal object GetStudentRegistration(DataTablesAjaxRequestModel dataTables)
        {
            var data = _studentRegistrationService.GetStudentRegistrations(
                                  dataTables.PageIndex,
                                   dataTables.PageSize,
                                  dataTables.SearchText,
                                  dataTables.GetSortText(new string[] { "Id", "StudentId", "CourseId" , "EnrollDate" ,"PaymentStutas" }));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.studentRegistrations
                        select new string[]
                        {
                                record.StudentId.ToString(),
                                record.CourseId.ToString(),
                                record.EnrollDate.ToString(),
                                record.IspaymentComplete.ToString(),
                                record.Id.ToString()
    }
                   ).ToArray()

            };
        }

        public IList<SelectListItem> GetStudentList()
        {
            IList<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var item in _studentRegistrationService.GetStudents())
            {
                var ctg = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };
                listItems.Add(ctg);
            }
            return listItems;
        }

        public IList<SelectListItem> GetCourseList()
        {
            IList<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var item in _studentRegistrationService.GetCourses())
            {
                var ctg = new SelectListItem
                {
                    Text = item.Title,
                    Value = item.Id.ToString()
                };
                listItems.Add(ctg);
            }
            return listItems;
        }
        internal string Delete(int Id)
        {
            var deleteRegistration = _studentRegistrationService.DeleteRegistration(Id);
            return deleteRegistration.Id.ToString();

        }
    }
}
