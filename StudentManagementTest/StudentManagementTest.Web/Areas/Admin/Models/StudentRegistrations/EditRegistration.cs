using StudentManagementTest.Library.Entity;
using StudentManagementTest.Library.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementTest.Web.Areas.Admin.Models.StudentRegistrations
{
    public class EditRegistration : StudentRegistrationModel
    {
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public DateTime EnrollDate { get; set; }

        public bool IspaymentComplete { get; set; }

        public EditRegistration() : base() { }
        public EditRegistration(IStudentRegistrationService studentRegistrationService) 
                                : base(studentRegistrationService) { }
        public void Edit()
        {
            var editRegistration = new StudentRegistration()
            {
                Id = this.Id,
                StudentId = this.StudentId,
                CourseId = this.CourseId,
                EnrollDate = this.EnrollDate,
                IspaymentComplete = this.IspaymentComplete
            };
            _studentRegistrationService.EditRegistration(editRegistration);
        }

        internal void Load(int id)
        {
            var registration = _studentRegistrationService.GetRegistration(id);
            if (registration != null)
            {
                Id = registration.Id;
                StudentId = registration.StudentId;
                CourseId = registration.CourseId;
                EnrollDate = registration.EnrollDate;
                IspaymentComplete = registration.IspaymentComplete;
            }
        }
    }
}
