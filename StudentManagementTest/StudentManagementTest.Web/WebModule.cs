using Autofac;
using StudentManagementTest.Web.Areas.Admin.Models.Course;
using StudentManagementTest.Web.Areas.Admin.Models.Student;
using StudentManagementTest.Web.Areas.Admin.Models.StudentRegistrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementTest.Web
{
    public class WebModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public WebModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
           
            builder.RegisterType<StudentModel>();
            builder.RegisterType<CourseModel>();
            builder.RegisterType<StudentRegistrationModel>();

            base.Load(builder);
        }
    }
}
