using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollSnap : MonoBehaviour
{
    private ScrollRect scrollRect;
    private Vector2 scrollContentCenter;

    private InputManager inputManager;
    private bool isDragging = false;

    private RectTransform[] scrollElements;



    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();

        scrollElements = new RectTransform[scrollRect.content.childCount];
        for (int i = 0; i < scrollElements.Length; i++)
        {
            scrollElements[i] = scrollRect.content.GetChild(i).GetComponent<RectTransform>();
        }


        inputManager.PerformedHoldEvent += OnDrag;
        inputManager.EndHoldEvent += OnStoppedDrag;

        scrollContentCenter = scrollRect.content.rect.center;

        scrollRect.onValueChanged.AddListener(OnScroll);
    }

    private void OnScroll(Vector2 pos)
    {

        if (!isDragging)
        {
            var velocity = scrollRect.velocity;
            if ((velocity.y < 5 || velocity.y > -5) && velocity.y != 0)
            {
                Debug.Log(FindClosestElementToCenter().name);
            }
        }
    }

    private RectTransform FindClosestElementToCenter()
    {
        RectTransform closestElem = scrollElements[0];
        float closestPos = scrollElements[0].anchoredPosition.y - scrollContentCenter.y;
        for (int i = 1; i < scrollElements.Length; i++)
        {
            float distToCenter = Mathf.Abs(scrollElements[i].anchoredPosition.y - scrollContentCenter.y);
            if (distToCenter < closestElem.anchoredPosition.y)
            {
                closestElem = scrollElements[i];
            }
        }

        return closestElem;
    }

    private void OnDrag(Vector2 pos)
    {
        isDragging = true;
    }

    private void OnStoppedDrag(Vector2 pos)
    {
        isDragging = false;
    }

    private void LerpToPosition(Vector2 targetPos, float duration)
    {

    }
}
