using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(-1)] // This have to be placed since the roomContainer would not be able to created fast enough and therefore be null
public class RoomArranger : MonoBehaviour
{
    [SerializeField] private RoomCreater _roomCreater;
    [SerializeField] private EditBehaviour _editBehaviour;
    [SerializeField] private DeleteRoom _deleteRoom;
    
    private RectTransform roomContainer;
    [SerializeField]
    private float spacing;

    public List<RectTransform> elements = new List<RectTransform>();

    private bool HasChildrenChanged
    {
        get
        {
            return roomContainer.childCount != elements.Count;
        }
    }

    private void OnEnable()
    {
        _roomCreater.OnCreateRoom += OnRoomsModified;
        _editBehaviour.OnDeleteRoomEvent += OnRoomsModified;
        _deleteRoom.OnDeleteRoom += OnRoomsModified;
    }

    private void OnDisable()
    {
        _roomCreater.OnCreateRoom -= OnRoomsModified;
        _editBehaviour.OnDeleteRoomEvent -= OnRoomsModified;
        _deleteRoom.OnDeleteRoom -= OnRoomsModified;
    }

    // Start is called before the first frame update 

    void Start()
    {
        roomContainer = GetComponent<RectTransform>();
        /*
        // Fill up the list with already existing UI elements
        RefreshChildElement();
        AdjustRoomContainerHeight();
        */
    }
    
    void OnRoomsModified()
    {
        RefreshChildElement();
        AdjustRoomContainerHeight();
    }
    

    public void ChangeChildOrder()
    {
        for (int i = 0; i < roomContainer.childCount; i++)
        {
            roomContainer.SetSiblingIndex(i);
        }
            
    }

    private void RefreshChildElement()
    {
        // Remove all already existing elements
        if (elements.Count > 0) elements.Clear();
        // Get new elements and cache them
        for (int i = 0; i < roomContainer.childCount; i++)
        {
            elements.Add(roomContainer.GetChild(i).GetComponent<RectTransform>());
        }
    }

    private void AdjustRoomContainerHeight()
    {
        Debug.Log("Rooms adjusted");
        float newHeight = 0;

        foreach (RectTransform room in elements)
        {
            newHeight += room.rect.height + spacing;
        }

        roomContainer.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newHeight);
    }

}
