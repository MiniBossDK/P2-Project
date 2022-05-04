using System;
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
    private int spacing;

    private RectTransform[] scrollElements;
    private float timeElapsed = 0;
    [Range(1, 10)]
    [Header("Animation duration")]
    [SerializeField] private float duration;

    private bool isAnimating = false;

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

        spacing = (int)Mathf.Abs(scrollElements[0].position.y - scrollElements[1].position.y);

        inputManager.PerformedHoldEvent += OnDrag;
        inputManager.EndHoldEvent += OnStoppedDrag;

        scrollContentCenter = scrollRect.content.rect.center;

        scrollRect.onValueChanged.AddListener(OnScroll);
    }

    private void OnScroll(Vector2 pos)
    {
        //var elem = FindClosestElementToCenter();


        //scrollRect.content.anchoredPosition = new Vector2(scrollRect.content.anchoredPosition.x, elem.anchoredPosition.y);

        //StartCoroutine(Lerp(scrollRect.content, elem.anchoredPosition.y, scrollContentCenter.y, duration));


        /*
        
        
        StartCoroutine(Lerp(scrollRect.content, position.y, scrollContentCenter.y, duration));
        */
        /*
        scrollRect.content.position = new Vector3(position.x, Mathf.Lerp(position.y, scrollContentCenter.y, timeElapsed / duration), 0);

        timeElapsed += Time.deltaTime;
        */



        /*
        Debug.Log(new Vector3(position.x, Mathf.Lerp(position.y, scrollContentCenter.y, timeElapsed / duration), 0));
        
        scrollRect.content.position = new Vector3(position.x, Mathf.Lerp(position.y, scrollContentCenter.y, timeElapsed / duration), 0);

        timeElapsed += Time.deltaTime;
        */
    }

    /*
    private RectTransform FindClosestElementToCenter()
    {
        //var closestElem = scrollElements[0];
        var closestDistToCenter = Mathf.Abs(scrollElements[0].position.y - scrollContentCenter.y);

        for (int i = 1; i < scrollElements.Length; i++)
        {
            var distToCenter = Mathf.Abs(scrollElements[i].position.y - scrollContentCenter.y);
            if (!(distToCenter < closestDistToCenter)) continue;
            smallestIndex = i;
            //closestElem = scrollElements[i];
            closestDistToCenter = distToCenter;
        }

        return smallestIndex;
    }
    */

    private void OnDrag(Vector2 pos)
    {
        isDragging = true;
    }

    private void OnStoppedDrag(Vector2 pos)
    {
        isDragging = false;
    }

    private void Lerp(int position)
    {
        var position1 = transform.position;
        float newX = Mathf.Lerp(position1.x, position, Time.deltaTime * 10f);
        Vector2 newPosition = new Vector2(newX, position1.y);
        scrollRect.content.position = newPosition;
    }
}
