using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class StickyPlusButtonHandler : MonoBehaviour
{
    [SerializeField] private RectTransform _addRoomBtn;
    [SerializeField] private RectTransform _stickPoint;
    private ScrollRect _scrollRect;
    private bool _isSticky = false;

    private void Start()
    {
        _scrollRect = GetComponent<ScrollRect>();
        _scrollRect.onValueChanged.AddListener(OnScroll);
    }

    private void OnScroll(Vector2 dir)
    {
        /*
        if (dir.y > 0)
        {
            if (_stickPoint.transform.position.y >= _addRoomBtn.transform.position.y)
            {
                Debug.Log("yes");
            }
            else
            {

            }
        }
        */
    }
}
