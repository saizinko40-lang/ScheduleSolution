using NUnit.Framework;
using Schedule.Core.Models;
using Schedule.Core.Services;
using System;

namespace Schedule.Tests.SchedulerTests
{
    public class SchedulerTests
    {
        [Test]
        public void TwoRequests_SameTime_HigherPriorityWins()
        {
            // Arrange
            var scheduler = new Scheduler(1); // N = 1 computer

            var lowPriorityRequest = new Request
            {
                Day = DayOfWeek.Monday,
                StartTime = TimeSpan.FromHours(9),
                EndTime = TimeSpan.FromHours(10.5),
                GroupName = "PI-11",
                GroupPriority = 1,
                LastName = "Petrov"
            };

            var highPriorityRequest = new Request
            {
                Day = DayOfWeek.Monday,
                StartTime = TimeSpan.FromHours(9),
                EndTime = TimeSpan.FromHours(10.5),
                GroupName = "PI-21",
                GroupPriority = 2,
                LastName = "Ivanov"
            };

            // Act
            scheduler.AddRequest(lowPriorityRequest);
            scheduler.AddRequest(highPriorityRequest);

            var schedule = scheduler.GetScheduleForDay(DayOfWeek.Monday);

            // Assert
            Assert.AreEqual(1, schedule.Count);
            Assert.AreEqual("PI-21", schedule[0].GroupName);
        }
    }
}