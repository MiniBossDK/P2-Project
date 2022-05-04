using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSpaceDifference : MonoBehaviour
{
    //[SerializeField] private RoomArranger listGetter;
    public List<GameObject> bodyList = new List<GameObject>();

    [SerializeField] GameObject spacer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckIfActive();
    }

    private void CheckIfActive()
    {
        bodyList.AddRange(GameObject.FindGameObjectsWithTag("Body"));

        if (bodyList.Count != 0)
        {
            foreach (GameObject bodyContent in bodyList)
            {
                
                bodyContent.transform.SetSiblingIndex(bodyContent.transform.parent.gameObject.transform.GetSiblingIndex()+1);
            }
        }

    }
}