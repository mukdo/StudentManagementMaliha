using StudentManagementTest.Framework;
using StudentManagementTest.Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentManagementTest.Library.Service
{
    public class CourseService : ICourseService
    {
        private ISMUnitOfWork _sMUnitOfWork;
        public CourseService( ISMUnitOfWork sMUnitOfWork)
        {
            _sMUnitOfWork = sMUnitOfWork;
        }
        public void AddCourse(Course course)
        {
            var count = _sMUnitOfWork.CourseRepository.GetCount(c => c.Title == course.Title);
            if(count>0)
                throw new DuplicationException("Course Name already exists", nameof(course.Title));

            _sMUnitOfWork.CourseRepository.Add(course);
            _sMUnitOfWork.Save();
        }

        public Course DeleteCourse(int Id)
        {
            var course = _sMUnitOfWork.CourseRepository.GetById(Id);
            _sMUnitOfWork.CourseRepository.Remove(Id);
            _sMUnitOfWork.Save();
            return course;
        }

        public void Dispose()
        {
            _sMUnitOfWork.Dispose();
        }

        public void EditCourse(Course course)
        { 
            var count = _sMUnitOfWork.CourseRepository.GetCount(x => x.Title == course.Title
                        && x.Id != course.Id);
            if (count > 0)
                throw new DuplicationException("Course already exists", nameof(course.Title));
            var editCourse = _sMUnitOfWork.CourseRepository.GetById(course.Id);
            editCourse.Title = course.Title;
            editCourse.Fee = course.Fee;
            editCourse.SeatCount = course.SeatCount;
            _sMUnitOfWork.Save();
        }

        public Course GetCourse(int Id)
        {
           return _sMUnitOfWork.CourseRepository.GetById(Id);
        }

        public (IList<Course> courses, int total, int totalDisplay) GetCourses(int pageindex, int Pagesize, string searchText, string sortText)
        {
            var result = _sMUnitOfWork.CourseRepository.GetAll().ToList();
            return (result, 0, 0);
        }
    }
}
