using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using System.IO;
using System.Linq;

public class RoomManager : JsonManager<Room>
{
    private List<Room> _rooms;

    public RoomManager() : base("rooms")
    {
        _rooms = LoadData();
    }

    public void AddRoom(Room room)
    {
        _rooms.Add(room);
        SaveData(_rooms);
    }
    
    /*
    public void DeleteRoom(Room room)
    {
        var newList = _rooms.Where(r => r.ID != room.ID).ToList();

        _rooms = newList;
        SaveData(_rooms);
    }
    */
}
