using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataTester : MonoBehaviour
{
    private RoomManager _roomManager;
    private TimerManager _timerManager;

    [SerializeField] private InputField inputField;
    [SerializeField] private Button confirmBtn;
    [SerializeField] private Button deleteBtn;
    void Awake()
    {
        _roomManager = new RoomManager();
        _timerManager = new TimerManager();
    }

    private void Start()
    {
        confirmBtn.onClick.AddListener(Confirm);
        deleteBtn.onClick.AddListener(Delete);
    }

    public void Confirm()
    {
        //
        _roomManager.AddRoom(new Room(inputField.text, 0, 0, 0));
        //_timerManager.AddTimer(new Timer(0, 24));
        //_timerManager.AddTimer(new Timer(1, 24));
    }

    public void Delete()
    {
        Debug.Log("Delete");

        _roomManager.DeleteRoom(room => room.Index == 0);
        _timerManager.DeleteTimer(timer => timer.StartTime == 0);

    }
}
