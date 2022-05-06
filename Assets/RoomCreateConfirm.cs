using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomCreateConfirm : MonoBehaviour
{
    private Button button;
    private RoomManager roomManager;

    private void Awake()
    {
        roomManager = new RoomManager();
    }
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(FinishRoomCreation);
    }

    private void FinishRoomCreation()
    {
        string roomName = PlayerPrefs.GetString("RoomName");
        string roomIconPath = PlayerPrefs.GetString("RoomIcon");

        roomManager.AddRoom(new Room(roomName, roomIconPath, 0, 0, 0));

        SceneChangeManager.LoadHomePage();
    }
}
