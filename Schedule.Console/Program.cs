using System;
using System.Text;
using Schedule.Core.Models;
using Schedule.Core.Services;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

Console.WriteLine("PROGRAM STARTED");

var scheduler = new Scheduler(1);

var request1 = new Request
{
    Day = DayOfWeek.Monday,
    StartTime = TimeSpan.FromHours(9),
    EndTime = TimeSpan.FromHours(10.5),
    GroupName = "PI-11",
    GroupPriority = 1,
    LastName = "Petrov"
};

var request2 = new Request
{
    Day = DayOfWeek.Monday,
    StartTime = TimeSpan.FromHours(9),
    EndTime = TimeSpan.FromHours(10.5),
    GroupName = "PI-21",
    GroupPriority = 2,
    LastName = "Ivanov"
};

scheduler.AddRequest(request1);
scheduler.AddRequest(request2);

var schedule = scheduler.GetScheduleForDay(DayOfWeek.Monday);

Console.WriteLine("=== Расписание машинного класса ===");
Console.WriteLine("День: Понедельник");

foreach (var entry in schedule)
{
    Console.WriteLine(
        $"{entry.StartTime:hh\\:mm} - {entry.EndTime:hh\\:mm} | " +
        $"Группа: {entry.GroupName} | {entry.LastName}"
    );
}

Console.WriteLine("END OF PROGRAM");
Console.ReadKey();