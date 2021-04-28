using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementTest.Data
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
