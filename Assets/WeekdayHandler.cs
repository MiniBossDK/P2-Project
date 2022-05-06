using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeekdayHandler : MonoBehaviour
{
    public List<WeekDay> EnabledWeekDays
    {
        get;
        private set;
    }

    private Sprite offCircle;
    private Sprite onCircle;

    void Start()
    {
        EnabledWeekDays = new List<WeekDay>();

        offCircle = Resources.Load<Sprite>("OffCircle");
        onCircle = Resources.Load<Sprite>("OnCircle");


        for (int i = 0; i < transform.childCount; i++)
        {
            Transform o = transform.GetChild(i);
            int childIndex = i;
            transform.GetChild(i).GetComponent<Button>().onClick.AddListener(() => OnWeekdayClicked(o, childIndex));
        }
    }

    private void OnWeekdayClicked(Transform clickedTransform, int childIndex)
    {
        Toggle(clickedTransform, GetWeekdayFromIndex(childIndex));
    }

    private WeekDay GetWeekdayFromIndex(int index)
    {
        switch (index)
        {
            case 0:
                return WeekDay.Monday;
            case 1:
                return WeekDay.Tuesday;
            case 2:
                return WeekDay.Wednesday;
            case 3:
                return WeekDay.Thursday;
            case 4:
                return WeekDay.Friday;
            case 5:
                return WeekDay.Saturday;
            case 6:
                return WeekDay.Sunday;
            default:
                return WeekDay.None;
        }
    }

    private void Toggle(Transform clickedTransform, WeekDay weekday)
    {
        Sprite clickedSprite = clickedTransform.GetComponent<Image>().sprite;
        if (clickedSprite == offCircle)
        {
            clickedTransform.GetComponent<Image>().sprite = onCircle;
            clickedTransform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black;
            EnabledWeekDays.Add(weekday);
        }
        else
        {
            clickedTransform.GetComponent<Image>().sprite = offCircle;
            clickedTransform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
            EnabledWeekDays.Remove(weekday);
        }
    }
}
