using System;
using UnityEngine;

[Serializable]
public struct Timer
{
    public Timer(Guid id, int startTime, int endTime)
    {
        ID = id.ToString();
        StartTime = startTime;
        EndTime = endTime;
    }
    public string ID;

    public string Name;

    public TimerType type;

    public int StartTime;

    public int EndTime;

    public WeekDay[] weekdays;

    public Room[] EnabledRooms;

}
