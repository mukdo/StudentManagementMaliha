using StudentManagementTest.Data;
using StudentManagementTest.Framework;
using StudentManagementTest.Library.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementTest.Library.Repository
{
    public interface IStudentRegistrationRepository : IRepository< StudentRegistration, int, SMDbContext>
    {
    }
}
