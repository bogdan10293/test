using System;

namespace General.Domain.Filters
{
    public class FilterFreeTimeSlots
    {
        public int EmployeeId { get; set; }
        public DateTime FromDT { get; set; }
        public DateTime ToDT { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
    }
}
