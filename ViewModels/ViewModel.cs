using MvcOvertime.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcOvertime.ViewModels
{
    public class ViewModel
    {
        public Overtime Overtime { get; set; }
        public Employee Employee { get; set; }
        public Admin Admin { get; set; }
    }
}
