using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerDropdownHandler : MonoBehaviour
{
    [SerializeField] private GameObject timePrefab;
    [SerializeField] private GameObject noTimersPrefab;
    private TimerManager _timerManager;

    private Sprite _downArrow;
    private Sprite _upArrow;
    
    private void Awake()
    {
        _timerManager = new TimerManager();
    }

    void Start()
    {
        _downArrow = Resources.Load<Sprite>("DropdownArrowDown");
        _upArrow = Resources.Load<Sprite>("DropdownArrowUp");
        var index = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            var btn = transform.GetChild(i);
            if(btn.CompareTag("Plus") || btn.CompareTag("Spacer")) continue;
            index++;
            var index1 = index;
            btn.GetComponent<Button>().onClick.AddListener(() => OnTimerClicked(index1, btn));
        }
    }

    private void OnTimerClicked(int index, Transform btn)
    {
        
        if (btn.childCount == 1)
        {
            OpenMenu(index, btn);
            btn.GetChild(0).GetChild(2).GetComponent<Image>().sprite = _upArrow;
        }
        else
        {
            CloseMenu(btn);
            btn.GetChild(0).GetChild(2).GetComponent<Image>().sprite = _downArrow;
        }
    }

    private void OpenMenu(int index, Transform btn)
    {
        var type = (TimerType) index;
        Debug.Log(type);
        var timers = _timerManager.GetAllTimers().FindAll(timer => timer.Type == type);

        if (timers.Count == 0)
        {
            Instantiate(noTimersPrefab, btn);
        }
        
        foreach (var timer in timers)
        {
            var time = Instantiate(timePrefab, btn);

            var timeName = time.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
            var timeText = time.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();

            const int timerBeautifierNumber = 10;
            
            timeName.text = timer.Name;

            string timerHour = (timer.TimeHours < timerBeautifierNumber) ? $"0:{timer.TimeHours}" : timer.TimeHours.ToString();
            string timerMin = (timer.TimeMin < timerBeautifierNumber) ? $"0{timer.TimeMin}" : timer.TimeMin.ToString();
            
            timeText.text = $"{timerHour}:{timerMin}";
        }
    }

    private void CloseMenu(Transform btn)
    {
        for (int i = 1; i < btn.childCount; i++)
        {
            Destroy(btn.GetChild(i).gameObject);
        }
    }
}
