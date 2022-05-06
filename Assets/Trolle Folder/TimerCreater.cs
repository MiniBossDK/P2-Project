using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DanielLochner.Assets.SimpleScrollSnap;

public class TimerCreater : MonoBehaviour
{
    private Button confirmBtn;
    private TimerManager timerManager;

    [SerializeField]
    private TMP_InputField timerName;
    [SerializeField]
    private DropMenuHandler timerType;
    [SerializeField]
    private GameObject hourContainer;
    [SerializeField]
    private GameObject minContainer;
    [SerializeField]
    private SimpleScrollSnap hourScroll;
    [SerializeField]
    private SimpleScrollSnap minScroll;
    [SerializeField]
    private WeekdayHandler selectedWeekDays;

    void Awake()
    {
        timerManager = new TimerManager();
    }

    private void Start()
    {
        confirmBtn = GetComponent<Button>();
        confirmBtn.onClick.AddListener(OnConfirmBtnClicked);
    }

    private void OnConfirmBtnClicked()
    {
        string name = timerName.text;
        TimerType type = timerType.SelectedItem;

        long startDateTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();

        Debug.Log(minScroll.SelectedPanel);

        int endTimeMin = Int32.Parse(GetScrollTextFromIndex(minScroll.SelectedPanel, minContainer.transform).text);
        int endTimeHour = Int32.Parse(GetScrollTextFromIndex(hourScroll.SelectedPanel, hourContainer.transform).text);
        long endDateTime = DateTimeOffset.Now.AddMinutes(endTimeMin).AddHours(endTimeHour).ToUnixTimeMilliseconds();

        List<WeekDay> weekdays = selectedWeekDays.EnabledWeekDays;

        SaveTimerData(name, type, startDateTime, endDateTime, weekdays);
    }

    private TextMeshProUGUI GetScrollTextFromIndex(int index, Transform scrollObject)
    {
        return scrollObject.GetChild(index).GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void SaveTimerData(string name, TimerType type, long startTime, long endTime, List<WeekDay> weekdays)
    {
        timerManager.AddTimer(new Timer(name, type, startTime, endTime, weekdays));
    }


}
