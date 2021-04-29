using StudentManagementTest.Data;
using StudentManagementTest.Framework;
using StudentManagementTest.Library.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementTest.Library.Repository
{
    public class StudentRepository : Repository<Student, int, SMDbContext>, IStudentRepository
    {
        public StudentRepository( SMDbContext sMDbContext) : base( sMDbContext)
        {

        }
    }
}
