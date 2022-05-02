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
    [SerializeField] private Button deleteBtn;

    private RoomManager _manager;

    private void Awake()
    {
        _manager = new RoomManager();
    }

    void Start()
    {
        confirmBtn.onClick.AddListener(SaveRoom);
        deleteBtn.onClick.AddListener(DeleteRoom);
    }

    private void SaveRoom()
    {
        _manager.AddRoom(new Room(roomName.text, 20f, 20f, 2));
    }

    private void DeleteRoom()
    {
        _manager.DeleteRoom(2);
    }
}
