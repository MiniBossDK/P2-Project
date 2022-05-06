using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public struct Timer
{
    public Timer(Guid id, string name, TimerType type, long startTime, long endTime, List<WeekDay> weekDays)
    {
        ID = id.ToString();
        Name = name;
        Type = type;
        StartTime = startTime;
        EndTime = endTime;
        Weekdays = weekDays.ToArray();
    }

    public Timer(string name, TimerType type, long startTime, long endTime, List<WeekDay> weekDays)
    {
        ID = Guid.NewGuid().ToString();
        Name = name;
        Type = type;
        StartTime = startTime;
        EndTime = endTime;
        Weekdays = weekDays.ToArray();
    }
    public string ID;

    public string Name;

    public TimerType Type;

    public long StartTime;

    public long EndTime;

    public WeekDay[] Weekdays;
}
