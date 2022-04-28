using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RoomFactory : MonoBehaviour
{
    [SerializeField]
    private InputField roomName;

    [SerializeField] private Button confirmBtn;

    private RoomManager _manager;

    private void Awake()
    { 
        _manager = new RoomManager();
    }

    void Start()
    {
        confirmBtn.onClick.AddListener(SaveRoom);
    }

    private void SaveRoom()
    {
        _manager.AddRoom(new Room(roomName.text, 20f, 20f, 0));
    }
}
