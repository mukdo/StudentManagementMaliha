using StudentManagementTest.Data;
using StudentManagementTest.Framework;
using StudentManagementTest.Library.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementTest.Library.Repository
{
    public class StudentRegistrationRepository : Repository<StudentRegistration, int, SMDbContext> , IStudentRegistrationRepository
    {
        public StudentRegistrationRepository( SMDbContext sMDbContext) : base(sMDbContext)
        {

        }
    }
}
