﻿using Autofac;
using StudentManagementTest.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;

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

            //builder.RegisterType<ApplicationDbContext>()
            //    .WithParameter("connectionString", _connectionString)
            //    .WithParameter("migrationAssemblyName", _migrationAssemblyName)
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<BlogUnitOfWork>().As<IBlogUnitOfWork>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<CategoryRepository>().As<ICategoryRepository>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<CategoryService>().As<ICategoryService>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<BlogComposeRepository>().As<IBlogComposeRepository>();
            //.InstancePerLifetimeScope();

            //builder.RegisterType<BlogComposeService>().As<IBlogComposeService>();
                //.InstancePerLifetimeScope();

           // builder.RegisterType<CommentRepository>().As<ICommentRepository>()
           //    .InstancePerLifetimeScope();

           // builder.RegisterType<CommentService>().As<ICommentService>()
           //     .InstancePerLifetimeScope();

           // builder.RegisterType<AccountSeed>()
           //     .InstancePerLifetimeScope();

           // builder.RegisterType<UserService>().As<IUserService>()
           //   .InstancePerLifetimeScope();

           // builder.RegisterType<CurrentUserService>().As<ICurrentUserService>()
           //.InstancePerLifetimeScope();


            base.Load(builder);
        }
    }
}
