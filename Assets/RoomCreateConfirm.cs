using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomCreateConfirm : MonoBehaviour
{
    private Button _button;
    private RoomManager _roomManager;

    private void Awake()
    {
        _roomManager = new RoomManager();
    }
    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(FinishRoomCreation);
    }

    private void FinishRoomCreation()
    {
        var roomName = PlayerPrefs.GetString("RoomName");
        var roomIconPath = PlayerPrefs.GetString("RoomIcon");

        _roomManager.AddRoom(new Room(roomName, roomIconPath, 0, 0, 0));

        SceneManager.LoadScene(0);
    }
}
