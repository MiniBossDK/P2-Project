using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSpaceDifference : MonoBehaviour
{

    [SerializeField] GameObject Body1, Body2, Body3, Body4;
    public GameObject WakeUp, Sleep, ComingHome, LeavingHome;

    // Update is called once per frame
    void Update()
    {
        //CheckIfActive();
        while (Body1 != null)
        {
            Sleep.transform.position = new Vector3(16f, -30f, 0f);
            ComingHome.transform.position = new Vector3(16f, -45f, 0f);
            LeavingHome.transform.position = new Vector3(16f, -60f, 0f);
        }
        while (Body2 != null)
        {
            ComingHome.transform.position = new Vector3(16f, -45f, 0f);
            LeavingHome.transform.position = new Vector3(16f, -60f, 0f);
        }
        while (Body3 != null)
        {
            LeavingHome.transform.position = new Vector3(16f, -60f, 0f);
        }
    }



    /*
    private void CheckIfActive()
    {
        bodyList.AddRange(GameObject.FindGameObjectsWithTag("Body"));

        if (bodyList.Count != 0)
        {
            foreach (GameObject bodyContent in bodyList)
            {

                    bodyContent.transform.SetSiblingIndex(bodyContent.transform.parent.gameObject.transform.GetSiblingIndex() + 1);

            }
        }

    }*/

}