using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcOvertime.Data;

namespace MvcOvertime.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OvertimeContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<OvertimeContext>>()))
            {
                if (context.Overtime.Any() && context.Employee.Any())
                {
                    return; // DB has been seeded
                }
                context.Overtime.AddRange(
                    new Overtime
                    {
                        NumberOfHours = 4,
                        StartTime = DateTime.Parse("18:00"),
                        EmployeeId = 5
                    },

                    new Overtime
                    {
                        NumberOfHours = 4,
                        StartTime = DateTime.Parse("1:00"),
                        EmployeeId = 6
                    },

                    new Overtime
                    {
                        NumberOfHours = 4,
                        StartTime = DateTime.Parse("12:00"),
                        EmployeeId = 4
                    },

                    new Overtime
                    {
                        NumberOfHours = 4,
                        StartTime = DateTime.Parse("7:00"),
                        EmployeeId = 3
                    }
                );

                context.Employee.AddRange(
                    new Employee
                    {
                        FirstName = "Dawood",
                        LastName = "Al-Oballi",
                        Department = "CEO"
                    },

                    new Employee
                    {
                        FirstName = "Darren",
                        LastName = "Jordan",
                        Department = "Game Developer"
                    },

                    new Employee
                    {
                        FirstName = "Daniel",
                        LastName = "Layland",
                        Department = "Project Manager"
                    },

                    new Employee
                    {
                        FirstName = "Muhammed",
                        LastName = "Miah",
                        Department = "Software Developer"
                    },

                    new Employee
                    {
                        FirstName = "Samantha",
                        LastName = "Haimes",
                        Department = "General Manager"
                    },

                    new Employee
                    {
                        FirstName = "Yanga",
                        LastName = "Lomuro",
                        Department = "Assistant Manager"
                    },

                    new Employee
                    {
                        FirstName = "Vinni",
                        LastName = "Victor",
                        Department = "HR"
                    }
                 );
                context.SaveChanges();
            }
        }
    }
}
