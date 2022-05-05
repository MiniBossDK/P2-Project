using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSceneRoomCreater : MonoBehaviour
{
    private RoomManager roomManager;
    private List<Room> roomList;
    public GameObject roomPrefab;
    public GameObject layerGroup;

    private void Awake()
    {
        roomManager = new RoomManager();
    }
    private void Start()
    {
        roomList = roomManager.GetAllRooms();
        InstantiateAllRooms();
    }

    private void InstantiateAllRooms()
    {
        foreach (Room room in roomList)
        {
            Instantiate(roomPrefab,layerGroup.transform);
            Debug.Log(room.Name);
        }
    }
}
