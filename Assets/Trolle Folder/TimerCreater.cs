using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCreater : MonoBehaviour
{
    private TimerManager timerManager;
    // Start is called before the first frame update
    void Start()
    {
        timerManager = new TimerManager();
    }


}
