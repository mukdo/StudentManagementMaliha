using StudentManagementTest.Library.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementTest.Library.Service
{
    public interface ICourseService : IDisposable
    {
        (IList<Course> courses, int total, int totalDisplay) GetCourses(int pageindex,
                                                                              int Pagesize,
                                                                              string searchText,
                                                                              string sortText);
        void AddCourse(Course course);
        void EditCourse(Course course);
        Course GetCourse(int Id);
        Course DeleteCourse(int Id);
    }
}
