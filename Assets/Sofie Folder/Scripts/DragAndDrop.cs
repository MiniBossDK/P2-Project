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
    private float speed = .1f;
    private Vector3 velocity = Vector3.zero;
    GameObject prevHitCollider;


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
        Ray ray = Camera.main.ScreenPointToRay(pos);
        RaycastHit2D Hit = Physics2D.GetRayIntersection(ray);
        if (Hit.collider != null)
        {
            Debug.Log("Started");
            elmToDrag = Hit.collider.gameObject.GetComponent<RectTransform>();
            initialPosition = elmToDrag.transform.position;
            initialIndex = elmToDrag.transform.GetSiblingIndex();
            prevHitCollider = elmToDrag.gameObject;
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
            if(Hit.collider != prevHitCollider && Hit.collider!= null)
            {
                prevHitCollider = Hit.collider.gameObject;
            }
            if (Hit.collider != null)
            {
                if(passedElements.Count >= 1)
                {
                    passedElements.RemoveAt(passedElements.Count - 1);
                }
                if (!passedElements.Contains(Hit.collider.gameObject.transform))
                {
                    if (elmToDrag.transform.position.y > Hit.collider.transform.position.y || elmToDrag.transform.position.y < Hit.collider.transform.position.y)
                    {
                        passedElements.Add(Hit.collider.gameObject.transform);
                        passedElements[passedElements.Count - 1].SetSiblingIndex(elmToDrag.GetSiblingIndex());
                    }
                }
            }
        }
    }

    private void SetElementPosition(Vector2 pos)
    {
        if(elmToDrag != null)
        {
 
           //elmToDrag.SetSiblingIndex(elmToDrag.GetSiblingIndex());

            SetRoomToSwitchElm(elmToDrag);
            passedElements.Clear();
            elmToDrag = null;
            scrollbar.vertical = true;
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


