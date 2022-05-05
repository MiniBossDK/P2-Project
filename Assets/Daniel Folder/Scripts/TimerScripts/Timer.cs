using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public struct Timer
{
    public Timer(Guid id, string name, TimerType type, int startTime, int endTime, List<WeekDay> weekDays, List<Guid> enabledRooms)
    {
        ID = id.ToString();
        Name = name;
        Type = type;
        StartTime = startTime;
        EndTime = endTime;
        Weekdays = weekDays.ToArray();
        EnabledRoomIds = enabledRooms.Select(id => id.ToString()).ToArray();
    }
    public string ID;

    public string Name;

    public TimerType Type;

    public int StartTime;

    public int EndTime;

    public WeekDay[] Weekdays;

    public string[] EnabledRoomIds;

}
