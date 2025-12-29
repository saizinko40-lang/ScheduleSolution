using Schedule.Core.Models;
using System;

namespace Schedule.Core.Services
{
    public class RequestValidator
    {
        public bool IsValid(Request request)
        {
            if (request == null)
                return false;

            // Check working hours: 08:00 – 18:00
            if (request.StartTime < TimeSpan.FromHours(8))
                return false;

            if (request.EndTime > TimeSpan.FromHours(18))
                return false;

            // Check duration is multiple of 90 minutes
            if (request.DurationInMinutes % 90 != 0)
                return false;

            return true;
        }
    }
} 