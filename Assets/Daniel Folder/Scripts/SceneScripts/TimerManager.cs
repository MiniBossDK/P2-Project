using System.Collections.Generic;
using System;

public class TimerManager : JsonManager<Timer>
{


    public TimerManager() : base("timers")
    {
        
    }

    public void AddTimer(Timer timer)
    {
        AddData(timer);
    }

    public void DeleteTimer(Predicate<Timer> predicate)
    {
        DeleteAllData(predicate);
    }

    public List<Timer> GetAllTimers()
    {
        return GetAllData();
    }

}
