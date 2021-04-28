using StudentManagementTest.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementTest.Library.Entity
{
    public class Student : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<StudentRegistration> StudentRegistrations { get; set; }

    }
}
