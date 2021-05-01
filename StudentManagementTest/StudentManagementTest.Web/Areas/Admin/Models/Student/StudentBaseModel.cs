using Autofac;
using StudentManagementTest.Library.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementTest.Web.Areas.Admin.Models.Student
{
    public class StudentBaseModel : AdminBaseModel , IDisposable
    {
       protected IStudentService _studentService;
        public StudentBaseModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
        }

        public StudentBaseModel( IStudentService studentService)
        {
            _studentService = studentService;
        }

        public void Dispose()
        {
            _studentService.Dispose();
        }
    }
}
