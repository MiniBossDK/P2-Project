using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DragAndDrop : MonoBehaviour
{
    public ScrollRect scrollbar;
    private InputManager inputManager;
    public RoomArranger roomArranger;
    private RectTransform elmToDrag;
    private List<Transform> passedElements = new List<Transform>();
    private Vector3 initialPosition;
    int initialIndex;
    public TextMeshProUGUI debugText;
    public TextMeshProUGUI debugText2;
    private float speed = .1f;
    private Vector3 velocity = Vector3.zero;


    void Start()
    {
        inputManager = InputManager.Instance;
        inputManager.PerformedHoldEvent += MoveElement;
        inputManager.StartHoldEvent += SetMoveableElement;
        inputManager.EndHoldEvent += SetElementPosition;
    }
    private void OnDisable()
    {
        inputManager.PerformedHoldEvent -= MoveElement;
        inputManager.StartHoldEvent -= SetMoveableElement;
        inputManager.EndHoldEvent -= SetElementPosition;
    }

    private void SetMoveableElement(Vector2 pos)
    {
        debugText.text = "StartPos " + pos.ToString();
        Ray ray = Camera.main.ScreenPointToRay(pos);
        RaycastHit2D Hit = Physics2D.GetRayIntersection(ray);
        if (Hit.collider != null)
        {
            Debug.Log("Started");
            elmToDrag = Hit.collider.gameObject.GetComponent<RectTransform>();
            initialPosition = elmToDrag.transform.position;
            initialIndex = elmToDrag.transform.GetSiblingIndex();
        }
    }
    private void MoveElement(Vector2 pos)
    {
        if (elmToDrag != null)
        {
            Debug.Log(passedElements.Count);
            Debug.Log("performed");
            scrollbar.vertical = false;
            Debug.Log(elmToDrag.GetSiblingIndex());
            float initialDistance = Vector3.Distance(elmToDrag.position, Camera.main.transform.position);
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit2D Hit = Physics2D.GetRayIntersection(ray);
            elmToDrag.transform.position = new Vector3(elmToDrag.transform.position.x, ray.GetPoint(initialDistance).y,
                ray.GetPoint(initialDistance).z);
            if (Hit.collider != null)
            {
                if (!passedElements.Contains(Hit.collider.gameObject.transform))
                {
                    if(elmToDrag.transform.position.y > Hit.collider.transform.position.y)
                    {
                        passedElements.Add(Hit.collider.gameObject.transform);
                        elmToDrag.SetSiblingIndex(elmToDrag.GetSiblingIndex() + 1);
                        Debug.Log(passedElements[2].GetSiblingIndex());

                    } else if (elmToDrag.transform.position.y < Hit.collider.transform.position.y)
                    {
                        passedElements.Add(Hit.collider.gameObject.transform);
                        elmToDrag.SetSiblingIndex(elmToDrag.GetSiblingIndex() - 1);
                    }
                }
            }
        }
    }

    private void SetElementPosition(Vector2 pos)
    {
        if(elmToDrag != null)
        {
            SetRoomToSwitchElm(elmToDrag);
            passedElements.Clear();
            elmToDrag = null;
        }
    }

    private void SetRoomToSwitchElm(RectTransform elmToDrag)
    {
        RectTransform roomToSwitch = null;
        float smallestDistance = Vector3.Distance(initialPosition, elmToDrag.transform.position);
        Debug.Log(smallestDistance);
        for (int i = 0; roomArranger.elements.Count > i; i++)
        {
            if (roomArranger.elements[i].gameObject != elmToDrag.gameObject)
            {
                if (Vector3.Distance(elmToDrag.transform.position, roomArranger.elements[i].transform.position) < smallestDistance)
                {
                    smallestDistance = Vector3.Distance(elmToDrag.transform.position, roomArranger.elements[i].transform.position);
                    roomToSwitch = roomArranger.elements[i];
                    elmToDrag.SetSiblingIndex(roomToSwitch.GetSiblingIndex());
                }
            } else
            {
                elmToDrag.position = initialPosition;
                elmToDrag.SetSiblingIndex(initialIndex);
            }
        }
    }
}


