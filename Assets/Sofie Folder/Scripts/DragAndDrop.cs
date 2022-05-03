using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DragAndDrop : MonoBehaviour
{
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
        inputManager.StartHoldEvent += SetMoveableElement;
        inputManager.PerformedHoldEvent += MoveElement;
        inputManager.EndHoldEvent += SetElementPosition;
    }
    private void OnDisable()
    {
        inputManager.StartHoldEvent -= SetMoveableElement;
        inputManager.PerformedHoldEvent -= MoveElement;
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
            Debug.Log("performed");
            float initialDistance = Vector3.Distance(elmToDrag.position, Camera.main.transform.position);
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit2D Hit = Physics2D.GetRayIntersection(ray);
            elmToDrag.transform.position = new Vector3(elmToDrag.transform.position.x, ray.GetPoint(initialDistance).y, ray.GetPoint(initialDistance).z);
            /*elmToDrag.transform.position = Vector3.SmoothDamp(elmToDrag.transform.position, new Vector3(elmToDrag.transform.position.x, ray.GetPoint(initialDistance).y, ray.GetPoint(initialDistance).z),
               ref velocity, speed);*/
        }
    }

    private void SetElementPosition(Vector2 pos)
    {
        Debug.Log("canceled");
        if(elmToDrag != null)
        {
            Debug.Log(SetRoomToSwitchElm(elmToDrag));
            if (SetRoomToSwitchElm(elmToDrag) != null)
            {
                RectTransform RoomForSwitch = SetRoomToSwitchElm(elmToDrag);
                elmToDrag.transform.position = RoomForSwitch.position;
                RoomForSwitch.transform.position = initialPosition;
            }
            
            elmToDrag = null;
        }
    }

    private RectTransform SetRoomToSwitchElm(RectTransform elmToDrag)
    {
        {
            RectTransform roomToSwitch = null;
            for (int i = 0; roomArranger.elements.Count > i; i++)
            {
                float smallestDistance = Vector3.Distance(roomArranger.elements[0].transform.position, roomArranger.elements[roomArranger.elements.Count - 1].transform.position);
                Debug.Log(smallestDistance);
                if (roomArranger.elements[i].gameObject != elmToDrag.gameObject)
                {
                    if (Vector3.Distance(elmToDrag.transform.position, roomArranger.elements[i].transform.position) < smallestDistance)
                    {
                        Debug.Log(smallestDistance);
                        return roomToSwitch = roomArranger.elements[i];
                        //elm to drag index = roomToSwitch index
                        //(if(roomArranger.elements[i] gameObject != elmToDrag.gameobject))
                            //roomArranger.elements[i] = dens index - 1
                    }
                }
            }
            return null;
        }
    }
}

/*RectTransform roomToSwitch = null;
            Vector2 smallestDistance = new Vector2(20000, 20000);
            foreach (RectTransform roomTransform in roomArranger.elements)
            {
                Vector2 distance = new Vector2(pos.x - roomTransform.position.x, pos.y - roomTransform.position.y);
                if (distance.x <= smallestDistance.x && distance.y <= smallestDistance.y && roomTransform.position != elmToDrag.position)
                {
                    roomToSwitch = roomTransform;
                }
            }
            elmToDrag.transform.position = roomToSwitch.transform.position;
            elmToDrag = null;

            //elmToDrag.transform.position = room.transform.position;
            //room.transform.position = elmToDrag.transform.position;

        }*/