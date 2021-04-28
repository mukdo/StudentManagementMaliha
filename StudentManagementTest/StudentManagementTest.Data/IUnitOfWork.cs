using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementTest.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
