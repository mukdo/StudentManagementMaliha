using Autofac;
using StudentManagementTest.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using StudentManagementTest.Library.Repository;
using StudentManagementTest.MemberShip.Contexts;
using StudentManagementTest.Library.Service;

namespace StudentManagementTest.Framework
{
    public class FrameworkModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FrameworkModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SMDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<SMUnitOfWork>().As<ISMUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentRepository>().As<IStudentRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CourseRepository>().As<ICourseRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentRegistrationRepository>().As<IStudentRegistrationRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentService>().As<IStudentService>();
                //.InstancePerLifetimeScope();

            builder.RegisterType<CourseService>().As<ICourseService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentRegistrationService>().As<IStudentRegistrationService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
