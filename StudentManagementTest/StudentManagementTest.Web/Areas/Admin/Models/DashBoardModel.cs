using StudentManagementTest.Library.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementTest.Web.Areas.Admin.Models
{
    public class DashBoardModel : AdminBaseModel  
    {
        private IStudentRegistrationService _studentRegistrationService;

        public DashBoardModel( IStudentRegistrationService studentRegistrationService) 
        {
            _studentRegistrationService = studentRegistrationService;
        }
        public DashBoardModel()
        {

        }

        public int count()
        {
        
                var count = _studentRegistrationService.Count();
            return count;
        }
    }
}
