using StudentManagementTest.Framework;
using StudentManagementTest.Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentManagementTest.Library.Service
{
    public class StudentRegistrationService : IStudentRegistrationService
    {
        private ISMUnitOfWork _sMUnitOfWork;
        public StudentRegistrationService( ISMUnitOfWork sMUnitOfWork)
        {
            _sMUnitOfWork = sMUnitOfWork;
        }
        public void AddRegistration(StudentRegistration studentRegistration)
        {
            _sMUnitOfWork.StudentRegistrationRepository.Add(studentRegistration);
            _sMUnitOfWork.Save();
        }

        public StudentRegistration DeleteRegistration(int Id)
        {
            var cancelRegistration = _sMUnitOfWork.StudentRegistrationRepository.GetById(Id);
            _sMUnitOfWork.StudentRegistrationRepository.Remove(cancelRegistration);
            _sMUnitOfWork.Save();
            return cancelRegistration;
        }

        public void Dispose()
        {
            _sMUnitOfWork.Dispose();
        }

        public void EditRegistration(StudentRegistration studentRegistration)
        {
            var editRegistration = _sMUnitOfWork.StudentRegistrationRepository.GetById(studentRegistration.Id);
            editRegistration.StudentId = studentRegistration.StudentId;
            editRegistration.CourseId = studentRegistration.CourseId;
            editRegistration.EnrollDate = studentRegistration.EnrollDate;
            editRegistration.IspaymentComplete = studentRegistration.IspaymentComplete;
            _sMUnitOfWork.Save();

        }

        public StudentRegistration GetRegistration(int Id)
        {
            return _sMUnitOfWork.StudentRegistrationRepository.GetById(Id);
        }

        public (IList<StudentRegistration> studentRegistrations, int total, int totalDisplay) GetStudentRegistrations(int pageindex, int Pagesize, string searchText, string sortText)
        {
            var result = _sMUnitOfWork.StudentRegistrationRepository.GetAll().ToList();
            return (result, 0, 0);
        }

        public IList<Student> GetStudents()
        {
            return _sMUnitOfWork.StudentRepository.GetAll();
        }

        public IList<Course> GetCourses()
        {
            return _sMUnitOfWork.CourseRepository.GetAll();
        }

        public int Count()
        {
            return _sMUnitOfWork.StudentRegistrationRepository.GetCount();
        }
    }
}
