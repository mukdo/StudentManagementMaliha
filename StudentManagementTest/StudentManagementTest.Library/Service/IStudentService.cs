using StudentManagementTest.Library.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementTest.Library.Service
{
    public interface IStudentService : IDisposable
    {
        (IList<Student> students, int total, int totalDisplay) GetStudents(int pageindex,
                                                                              int Pagesize,
                                                                              string searchText,
                                                                              string sortText);
        void AddStudent(Student student);
        void EditStudent(Student student);
        Student GetStudent(int Id);
        Student DeleteStudent(int Id);
    }
}
