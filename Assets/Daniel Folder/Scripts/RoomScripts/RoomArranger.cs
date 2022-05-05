using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomArranger : MonoBehaviour
{
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

    // Start is called before the first frame update

    void Start()
    {
        roomContainer = GetComponent<RectTransform>();
        // Fill up the list with already existing UI elements
        RefreshChildElement();
        AdjustRoomContainerHeight();
    }

    
    // TODO - Change this to be event based from the add room feauture
    void Update()
    {
        if (HasChildrenChanged)
        {
            RefreshChildElement();
            AdjustRoomContainerHeight();
        }
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
        float newHeight = 0;

        foreach (RectTransform room in elements)
        {
            newHeight += room.rect.height + spacing;
        }

        roomContainer.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newHeight);
    }

}
