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

    public void DeleteRoom(int index)
    {
        _rooms = LoadData();
        Debug.Log("Before filtering: " + _rooms.Count);
        var newList = _rooms.Where(r => r.Index != index).ToList();
        _rooms = newList;
        Debug.Log("After filtering: " + _rooms.Count);
        SaveData(newList);
    }

}
