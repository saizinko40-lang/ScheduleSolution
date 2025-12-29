using NUnit.Framework;
using Schedule.Core.Models;
using Schedule.Core.Services;
using System;

namespace Schedule.Tests.ValidatorTests
{
    public class RequestValidatorTests
    {
        [Test]
        public void Request_WithInvalidDuration_ShouldBeInvalid()
        {
            // Arrange
            var request = new Request
            {
                Day = DayOfWeek.Monday,
                StartTime = TimeSpan.FromHours(9),
                EndTime = TimeSpan.FromHours(10), // 60 minutes (invalid)
                GroupName = "PI-21",
                GroupPriority = 1,
                LastName = "Ivanov"
            };

            var validator = new RequestValidator();

            // Act
            bool result = validator.IsValid(request);

            // Assert
            Assert.IsFalse(result);
        }
    }
}