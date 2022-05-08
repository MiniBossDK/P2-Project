using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DanielLochner.Assets.SimpleScrollSnap;
using UnityEngine.SceneManagement;

public class TimerCreater : MonoBehaviour
{
    private Button confirmBtn;
    private TimerManager timerManager;
    [SerializeField] private int timerSceneIndex;
    
    
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

        int timeMin = Int32.Parse(GetScrollTextFromIndex(minScroll.SelectedPanel, minContainer.transform).text);
        int timeHours = Int32.Parse(GetScrollTextFromIndex(hourScroll.SelectedPanel, hourContainer.transform).text);

        Debug.Log(timeMin);
        Debug.Log(timeHours);
        
        List<WeekDay> weekdays = selectedWeekDays.EnabledWeekDays;

        SaveTimerData(name, type, timeHours, timeMin, weekdays);
        SceneManager.LoadScene(timerSceneIndex);
    }

    private TextMeshProUGUI GetScrollTextFromIndex(int index, Transform scrollObject)
    {
        return scrollObject.GetChild(index).GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void SaveTimerData(string timerDataName, TimerType type, int timeHours, int timeMin, List<WeekDay> weekdays)
    {
        timerManager.AddTimer(new Timer(timerDataName, type, timeHours, timeMin, weekdays));
    }


}
