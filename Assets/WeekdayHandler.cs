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

    private Sprite _offCircle;
    private Sprite _onCircle;

    void Start()
    {
        EnabledWeekDays = new List<WeekDay>();

        _offCircle = Resources.Load<Sprite>("OffCircle");
        _onCircle = Resources.Load<Sprite>("OnCircle");


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
        return index switch
        {
            0 => WeekDay.Monday,
            1 => WeekDay.Tuesday,
            2 => WeekDay.Wednesday,
            3 => WeekDay.Thursday,
            4 => WeekDay.Friday,
            5 => WeekDay.Saturday,
            6 => WeekDay.Sunday,
            _ => WeekDay.None
        };
    }

    private void Toggle(Transform clickedTransform, WeekDay weekday)
    {
        Sprite clickedSprite = clickedTransform.GetComponent<Image>().sprite;
        if (clickedSprite == _offCircle)
        {
            clickedTransform.GetComponent<Image>().sprite = _onCircle;
            clickedTransform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black;
            EnabledWeekDays.Add(weekday);
        }
        else
        {
            clickedTransform.GetComponent<Image>().sprite = _offCircle;
            clickedTransform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
            EnabledWeekDays.Remove(weekday);
        }
    }
}
