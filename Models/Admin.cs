﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcOvertime.Models
{
    public class Admin
    {
        public Admin()
        {
            Employees = new HashSet<Employee>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
