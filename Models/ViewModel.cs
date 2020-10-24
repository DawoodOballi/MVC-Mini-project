using MvcOvertime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcOvertime.Models
{
    public class ViewModel
    {
        public Overtime Overtime { get; set; }
        public Employee Employee { get; set; }
    }
}
