using StudentManagementTest.Library.Entity;
using StudentManagementTest.Library.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementTest.Web.Areas.Admin.Models.StudentRegistrations
{
    public class CreateRegistrationModel : StudentRegistrationModel
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public DateTime EnrollDate { get; set; }
  
        public bool IspaymentComplete { get; set; }

        public CreateRegistrationModel() : base() { }
        public CreateRegistrationModel( IStudentRegistrationService studentRegistrationService) 
                                        : base(studentRegistrationService) { }

        public void AddRegistration()
        {
            var registration = new StudentRegistration()
            {
                StudentId = this.StudentId,
                CourseId = this.CourseId,
                EnrollDate = this.EnrollDate,
                IspaymentComplete = this.IspaymentComplete
            };
            _studentRegistrationService.AddRegistration(registration);
        }


       
    }
}
