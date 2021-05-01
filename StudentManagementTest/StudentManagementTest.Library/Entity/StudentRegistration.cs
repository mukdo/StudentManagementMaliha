using StudentManagementTest.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentManagementTest.Library.Entity
{
    public class StudentRegistration : IEntity<int>
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        public DateTime EnrollDate { get; set; }
        public bool IspaymentComplete { get; set; }
    }
}
