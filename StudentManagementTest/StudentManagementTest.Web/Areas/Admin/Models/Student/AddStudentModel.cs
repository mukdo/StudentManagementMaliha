using StudentManagementTest.Library.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StudentManagementTest.Library.Entity;
namespace StudentManagementTest.Web.Areas.Admin.Models.Student
{
    public class AddStudentModel : StudentBaseModel
    {
        [Required]
        public string Name { get; set; }    
        [Required]
        public DateTime DateOfBirth { get; set; }

        public AddStudentModel(IStudentService studentService) : base(studentService)
        {

        }

        public AddStudentModel() : base()
        {

        }

        public void Add()
        {
            var student = new StudentManagementTest.Library.Entity.Student()
            {
                Name = this.Name,
                DateOfBirth = this.DateOfBirth
            };
            _studentService.AddStudent(student);
        }

    }
}
