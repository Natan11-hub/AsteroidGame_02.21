using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using EmployeesManager.Models;

namespace EmployeesManager.Data
{
    class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Departament> Departaments { get; set; }

        public DataContext(string ConnectionString) : base(ConnectionString)
        {

        }

        public DataContext() : this("Name=DefConnection")
        {
        }
    }
}
