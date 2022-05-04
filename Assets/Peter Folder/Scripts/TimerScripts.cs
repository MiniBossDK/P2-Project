using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class TimerScripts : MonoBehaviour
{
    //From tutorial: https://www.youtube.com/watch?v=zHAsc5H0j2c&ab_channel=MetalStormGames

    [SerializeField] private TextMeshProUGUI timetext;
    [SerializeField] private TMP_InputField hoursInput, minutesInput, secondsInput;

    private bool isAlarmSet = false;
    private DateTime alarmTime = DateTime.Today;

    public static TimerScripts timerScript;

    void Awake()
    {
        if (timerScript == null)
        {
            timerScript = this;
        }
        else if (timerScript != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        int hours = DateTime.Now.Hour;
        int minutes = DateTime.Now.Minute;
        int seconds = DateTime.Now.Second;

        timetext.text = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        

        if (isAlarmSet && DateTime.Now > alarmTime)
        {
            Debug.Log("Unreal er bedre");
            //Later functionality to be implemented
        }
        
    }

    public void SetAlarm()
    {
        TimeSpan ts = TimeSpan.Parse($"{hoursInput.text}:{minutesInput.text}:{secondsInput.text}");
        alarmTime += ts;

        isAlarmSet = true;
        Debug.Log("test");
    }
}
