using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using TMPro;

public class RoomCreater : MonoBehaviour
{
    public delegate void CreateRoomEvent();
    public event CreateRoomEvent OnCreateRoom;
    
    [SerializeField] private GameObject roomContainer;
    [SerializeField] private GameObject roomPrefab;

    private RoomManager _roomManager;

    void Start()
    {
        _roomManager = new RoomManager();

        foreach (var room in _roomManager.GetAllRooms().OrderByDescending(room => room.Index))
        {
            Sprite icon = Resources.Load<Sprite>("RoomIconsNoBackground/" + room.RoomIconPath);
            var roomUI = Instantiate(roomPrefab, roomContainer.transform);
            roomUI.name = room.ID;
            var roomText = roomUI.GetComponentInChildren<TextMeshProUGUI>();
            var roomIcon = roomUI.transform.Find("Upper/LeftSide/RoomInfo/Icon/RoomIcon").GetComponent<Image>().sprite = icon;

            roomText.text = room.Name;
            roomUI.transform.SetAsFirstSibling();
            OnCreateRoom?.Invoke();
        }
    }
}
