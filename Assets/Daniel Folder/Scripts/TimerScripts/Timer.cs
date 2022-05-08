using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public struct Timer
{
    public Timer(Guid id, string name, TimerType type, int timeHours, int timeMin, List<WeekDay> weekDays)
    {
        ID = id.ToString();
        Name = name;
        Type = type;
        TimeHours = timeHours;
        TimeMin = timeMin;
        Weekdays = weekDays.ToArray();
    }

    public Timer(string name, TimerType type, int timeHours, int timeMin, List<WeekDay> weekDays)
    {
        ID = Guid.NewGuid().ToString();
        Name = name;
        Type = type;
        TimeHours = timeHours;
        TimeMin = timeMin;
        Weekdays = weekDays.ToArray();
    }
    public string ID;

    public string Name;

    public TimerType Type;

    public int TimeHours;

    public long TimeMin;

    public WeekDay[] Weekdays;
}
