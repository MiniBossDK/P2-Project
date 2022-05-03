using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimerScripts : MonoBehaviour
{
    //From tutorial: https://www.youtube.com/watch?v=zHAsc5H0j2c&ab_channel=MetalStormGames

    [SerializeField] private TextMeshProUGUI timetext;
    [SerializeField] private TMP_InputField hoursInput, minutesInput;

    private bool isAlarmSet = false;
    private DateTime alarmTime = DateTime.Today;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        int hours = DateTime.Now.Hour;
        int minutes = DateTime.Now.Minute;

        timetext.text = $"{hours:D2}:{minutes:D2}";

        if (isAlarmSet && DateTime.Now > alarmTime)
        {
            Debug.Log("Unreal er bedre");
        }

    }

    public void SetAlarm()
    {
        TimeSpan ts = TimeSpan.Parse($"{hoursInput.text}:{minutesInput.text}");
        alarmTime += ts;

        isAlarmSet = true;
    }
}
