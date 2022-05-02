using System;
using UnityEngine;

[Serializable]
public struct Timer
{
    public Timer(int startTime, int endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
    }

    public int StartTime;

    public int EndTime;
    
}
