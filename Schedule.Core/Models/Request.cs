using System;

namespace Schedule.Core.Models
{
    public class Request
    {
        public DayOfWeek Day { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public string GroupName { get; set; }

        public int GroupPriority { get; set; }

        public string LastName { get; set; }

        public int DurationInMinutes
        {
            get
            {
                return (int)(EndTime - StartTime).TotalMinutes;
            }
        }
    }
}
