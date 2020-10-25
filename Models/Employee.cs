using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MvcOvertime.Models
{
    public class Employee
    {
        public Employee()
        {
            Overtime = new HashSet<Overtime>();
        }

        [Display(Name = "Employee ID")]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Department { get; set; }
        public int? AdminId { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual ICollection<Overtime> Overtime { get; set; }

    }
}
