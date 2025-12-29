using Schedule.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Schedule.Core.Services
{
    public class Scheduler
    {
        private readonly int _computerCount;
        private readonly Dictionary<DayOfWeek, List<Request>> _requests;

        public Scheduler(int computerCount)
        {
            _computerCount = computerCount;
            _requests = new Dictionary<DayOfWeek, List<Request>>();
        }

        public void AddRequest(Request request)
        {
            if (!_requests.ContainsKey(request.Day))
            {
                _requests[request.Day] = new List<Request>();
            }

            _requests[request.Day].Add(request);

            ResolveConflicts(request.Day);
        }

        public List<Request> GetScheduleForDay(DayOfWeek day)
        {
            if (!_requests.ContainsKey(day))
                return new List<Request>();

            return _requests[day]
                .OrderBy(r => r.StartTime)
                .ToList();
        }

        private void ResolveConflicts(DayOfWeek day)
        {
            var dayRequests = _requests[day];

            var groupedByTime = dayRequests
                .GroupBy(r => new { r.StartTime, r.EndTime })
                .ToList();

            var resolved = new List<Request>();

            foreach (var group in groupedByTime)
            {
                var ordered = group
                    .OrderByDescending(r => r.GroupPriority)
                    .Take(_computerCount);

                resolved.AddRange(ordered);
            }

            _requests[day] = resolved;
        }
    }
}