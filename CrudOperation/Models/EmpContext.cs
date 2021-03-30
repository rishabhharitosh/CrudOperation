using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperation.Models
{
    public class EmpContext : DbContext
    {
        public EmpContext(DbContextOptions<EmpContext> options):base(options)
        {

        }
        public DbSet<Employee> tbl_Employee { get; set; }
        public DbSet<Departments> tbl_Department { get; set; }
    }
}
