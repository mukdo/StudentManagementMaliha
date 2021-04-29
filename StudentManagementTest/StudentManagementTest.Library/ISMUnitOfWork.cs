using StudentManagementTest.Data;
using StudentManagementTest.Library.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementTest.Framework
{
    public interface ISMUnitOfWork:IUnitOfWork
    {
        IStudentRepository StudentRepository { get; set; }
        ICourseRepository CourseRepository { get; set; }
        IStudentRegistrationRepository StudentRegistrationRepository { get; set; }
        
    }
}
