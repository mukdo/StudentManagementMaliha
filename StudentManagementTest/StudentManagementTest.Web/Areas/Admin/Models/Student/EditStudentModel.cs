using StudentManagementTest.Library.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementTest.Web.Areas.Admin.Models.Student
{
    public class EditStudentModel : StudentBaseModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        public EditStudentModel(IStudentService studentService) : base(studentService) { }
        public EditStudentModel() : base() { }

        public void Edit()
        {
            var editStudent = new StudentManagementTest.Library.Entity.Student()
            {
                Id = this.Id,
                Name = this.Name,
                DateOfBirth = this.DateOfBirth
            };
            _studentService.EditStudent(editStudent);
        }

        internal void Load( int id)
        {
            var student = _studentService.GetStudent(id);
            
            if(student !=null)
            {
                Id = student.Id;
                Name = student.Name;
                DateOfBirth = student.DateOfBirth;
            }
        }   
    }
}
