using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Employees.Models
{
    public class EmployeeDBContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}