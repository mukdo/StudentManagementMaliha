using StudentManagementTest.Library.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementTest.Library.Service
{
    public interface IStudentRegistrationService : IDisposable
    {
        (IList<StudentRegistration> studentRegistrations, int total, int totalDisplay) GetStudentRegistrations(int pageindex,
                                                                           int Pagesize,
                                                                           string searchText,
                                                                           string sortText);
        void AddRegistration(StudentRegistration studentRegistration);
        void EditRegistration(StudentRegistration studentRegistration);
        StudentRegistration GetRegistration(int Id);
        StudentRegistration DeleteRegistration(int Id);
        IList<Student> GetStudents();
        IList<Course> GetCourses();
    }
}
