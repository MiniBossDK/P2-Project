using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public struct Timer
{
    public Timer(Guid id, string name, TimerType type, int startTime, int endTime, List<WeekDay> weekDays, List<Room> enabledRooms)
    {
        ID = id.ToString();
        Name = name;
        Type = type;
        StartTime = startTime;
        EndTime = endTime;
        Weekdays = weekDays.ToArray();
        EnabledRooms = enabledRooms.ToArray();
    }
    public string ID;

    public string Name;

    public TimerType Type;

    public int StartTime;

    public int EndTime;

    public WeekDay[] Weekdays;

    public Room[] EnabledRooms;

}
