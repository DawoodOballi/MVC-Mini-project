using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOvertime.Models
{
    public class Overtime
    {
        public int Id { get; set; }


        public string Day => Date.DayOfWeek.ToString();


        public int NumberOfHours { get; set; }


        [DataType(DataType.Date)]
        public DateTime Date { get; set; }


        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }


        [DataType(DataType.Time)]
        public string EndTime => StartTime.AddHours(NumberOfHours).ToString("t", new CultureInfo("en-US"));


        [Display(Name ="Start Time")]
        public string DtStartTime => StartTime.ToString("t", new CultureInfo("en-US")); 

        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
