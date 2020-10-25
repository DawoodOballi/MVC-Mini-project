using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcOvertime.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MvcOvertime.Data
{
    public class OvertimeContext : IdentityDbContext
    {
        public OvertimeContext(DbContextOptions<OvertimeContext> options) : base(options)
        { 
        }

        public DbSet<Overtime> Overtime { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<MvcOvertime.Models.Admin> Admin { get; set; }
    }
}
