using Microsoft.EntityFrameworkCore;
using StudentManagementTest.Library.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementTest.Framework
{
    public class SMDbContext : DbContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public SMDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           

            base.OnModelCreating(builder);
        }

       // public DbSet<Course> Courses { get; set; }
       // public DbSet<Student> Students { get; set; }
       public DbSet<StudentRegistration> StudentRegistrations { get; set; }

    

       
    }
}
