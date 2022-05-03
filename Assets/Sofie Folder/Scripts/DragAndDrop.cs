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
        }
    }

    private void MoveElement(Vector2 pos)
    {
        if (elmToDrag != null)
        {
            Debug.Log(passedElements.Count);
            Debug.Log("performed");
            scrollbar.vertical = false;
            
            float initialDistance = Vector3.Distance(elmToDrag.position, Camera.main.transform.position);
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit2D Hit = Physics2D.GetRayIntersection(ray);
            elmToDrag.transform.position = new Vector3(elmToDrag.transform.position.x, ray.GetPoint(initialDistance).y,
                ray.GetPoint(initialDistance).z);
            if (Hit.collider != null)
            {
                if (!passedElements.Contains(Hit.collider.gameObject.transform))
                {
                    if(ray.GetPoint(initialDistance).y > Hit.collider.transform.position.y)
                    {
                        passedElements.Add(Hit.collider.gameObject.transform);
                        elmToDrag.SetSiblingIndex(elmToDrag.GetSiblingIndex() + 1);
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
            elmToDrag = null;
        }
    }

    private void SetRoomToSwitchElm(RectTransform elmToDrag)
    {
            RectTransform roomToSwitch = null;
            for (int i = 0; passedElements.Count > i; i++)
            {
                float smallestDistance = Vector3.Distance(initialPosition, elmToDrag.transform.position);
                Debug.Log(smallestDistance);
                if (passedElements[i].gameObject != elmToDrag.gameObject)
                {
                    if (Vector3.Distance(elmToDrag.transform.position, passedElements[i].transform.position) < smallestDistance)
                    {
                        roomToSwitch = roomArranger.elements[i];
                        Debug.Log(smallestDistance);
                        elmToDrag.SetSiblingIndex(roomToSwitch.GetSiblingIndex());
                    }
                }
                else
                {
                    elmToDrag.position = initialPosition;
                }
            }
        }
    }


