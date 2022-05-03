using System;
using System.Collections.Generic;

public class RoomManager : JsonManager<Room>
{
    public RoomManager() : base("rooms")
    {
        
    }

    public void AddRoom(Room room)
    {
        AddData(room);
    }

    public void DeleteRoom(Predicate<Room> predicate)
    {
        DeleteAllData(predicate);
    }

    public List<Room> GetAllRooms()
    {
        return GetAllData();
    }

    public List<Room> GetRoom(Predicate<Room> filter)
    {
        return GetData(filter);
    }

}
