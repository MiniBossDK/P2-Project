using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneRoomCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject sceneRoomPrefab;
    private RoomManager _roomManager;

    private void Awake()
    {
        _roomManager = new RoomManager();
    }

    void Start()
    {
        foreach (var room in _roomManager.GetAllRooms())
        {
            var roomObject = Instantiate(sceneRoomPrefab, transform);
            roomObject.name = room.ID;
            roomObject.transform.SetSiblingIndex(transform.childCount - 2);
            var roomIcon = roomObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
            var roomName = roomObject.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();

            roomIcon.sprite = Resources.Load<Sprite>("RoomIconsNoBackground/" + room.RoomIconPath);
            roomName.text = room.Name;
        }
    }
}
