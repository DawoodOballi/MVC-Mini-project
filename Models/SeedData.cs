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
                if (context.Overtime.Any())
                {
                    return; // DB has been seeded
                }
                context.Overtime.AddRange(
                    new Overtime
                    {
                        NumberOfHours = 4,
                        StartTime = DateTime.Parse("18:00")
                    },

                    new Overtime
                    {
                        NumberOfHours = 4,
                        StartTime = DateTime.Parse("1:00")
                    },

                    new Overtime
                    {
                        NumberOfHours = 4,
                        StartTime = DateTime.Parse("12:00")
                    },

                    new Overtime
                    {
                        NumberOfHours = 4,
                        StartTime = DateTime.Parse("7:00")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
