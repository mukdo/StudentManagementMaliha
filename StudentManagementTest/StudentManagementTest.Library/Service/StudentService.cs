using StudentManagementTest.Framework;
using StudentManagementTest.Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentManagementTest.Library.Service
{
    public class StudentService : IStudentService
    {
        private ISMUnitOfWork _sMUnitOfWork;
        public StudentService( ISMUnitOfWork sMUnitOfWork)
        {
            _sMUnitOfWork = sMUnitOfWork;
        }
        public void AddStudent(Student student)
        {
            _sMUnitOfWork.StudentRepository.Add(student);
            _sMUnitOfWork.Save();
        }

        public Student DeleteStudent(int Id)
        {
            var student = _sMUnitOfWork.StudentRepository.GetById(Id);
            _sMUnitOfWork.StudentRepository.Remove(Id);
            _sMUnitOfWork.Save();
            return student;
        }

        public void Dispose()
        {
            _sMUnitOfWork.Dispose();
        }

        public void EditStudent(Student student)
        {
            var editStudent = _sMUnitOfWork.StudentRepository.GetById(student.Id);
            editStudent.Name = student.Name;
            editStudent.DateOfBirth = student.DateOfBirth;
            _sMUnitOfWork.Save();
        }

        public Student GetStudent(int Id)
        {
            return _sMUnitOfWork.StudentRepository.GetById(Id);
        }

        public (IList<Student> students, int total, int totalDisplay) GetStudents(int pageindex, int Pagesize, string searchText, string sortText)
        {
            var result = _sMUnitOfWork.StudentRepository.GetAll().ToList();
            return (result, 0, 0);
        }
    }
}
