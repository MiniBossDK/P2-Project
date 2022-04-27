using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusButtonHandler : MonoBehaviour
{
    [SerializeField] private RectTransform limitRect;
    [SerializeField] private RectTransform plusButton;

    [SerializeField] private GameObject parentSticky;

    [SerializeField] private GameObject roomContent;

    private bool isSticky;

    private void Start()
    {
        // TODO: Get events from the script that creates a new room to refresh the UI
        isSticky = plusButton.parent == parentSticky.transform;
    }

    void Update()
    {
        Debug.Log(plusButton.anchoredPosition.y < limitRect.anchoredPosition.y);
        /*
        if (isSticky)
        {
            if (roomContent.transform.childCount <= 6)
            {
                plusButton.SetParent(roomContent.transform);
                plusButton.transform.SetSiblingIndex(5);
                isSticky = false;
            }
        }
        else if (!isSticky)
        {
            if (roomContent.transform.childCount > 7)
            {
                plusButton.SetParent(parentSticky.transform);
                isSticky = true;
            }
        }
        */
    }
}
