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
    [SerializeField] private GameObject roomContainer;
    [SerializeField] private GameObject roomPrefab;

    private RoomManager _roomManager;
    private Button _button;
    void Start()
    {
        _button = GetComponent<Button>();
        _roomManager = new RoomManager();
        _button.onClick.AddListener(AddRoomToUI);

        foreach (var room in _roomManager.GetAllRooms().OrderByDescending(room => room.Index))
        {
            var roomUI = Instantiate(roomPrefab, roomContainer.transform);
            roomUI.name = room.ID;
            var roomText = roomUI.GetComponentInChildren<TextMeshProUGUI>();
            roomText.text = room.Name;
            roomUI.transform.SetAsFirstSibling();
        }
    }

    private void AddRoomToUI()
    {
        var roomName = "Living Room";
        var roomUI = Instantiate(roomPrefab, roomContainer.transform);
        var roomText = roomUI.GetComponentInChildren<TextMeshProUGUI>();
        roomText.text = roomName;
        Room room = new Room(roomName, 0, 0, 0);
        _roomManager.AddRoom(room);
        roomUI.name = room.ID;
        roomUI.transform.SetAsFirstSibling();
    }
    
    
}
