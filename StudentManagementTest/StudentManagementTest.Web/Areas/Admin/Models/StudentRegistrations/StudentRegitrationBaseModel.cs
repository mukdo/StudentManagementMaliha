using Autofac;
using StudentManagementTest.Library.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementTest.Web.Areas.Admin.Models.StudentRegistrations
{
    public class StudentRegitrationBaseModel : AdminBaseModel, IDisposable
    {
        protected IStudentRegistrationService _studentRegistrationService;

        public StudentRegitrationBaseModel()
        {
            _studentRegistrationService = Startup.AutofacContainer.Resolve<IStudentRegistrationService>();
        }

        public StudentRegitrationBaseModel( IStudentRegistrationService studentRegistrationService)
        {
            _studentRegistrationService = studentRegistrationService;
        }

        public void Dispose()
        {
            _studentRegistrationService.Dispose();
        }
    }
}
