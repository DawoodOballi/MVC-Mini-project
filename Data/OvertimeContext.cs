using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcOvertime.Models;

namespace MvcOvertime.Data
{
    public class OvertimeContext : DbContext
    {
        public OvertimeContext(DbContextOptions<OvertimeContext> options) : base(options)
        { 
        }

        public DbSet<Overtime> Overtime { get; set; }
    }
}
