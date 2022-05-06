using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DanielLochner.Assets.SimpleScrollSnap;

public class AddTimerData : MonoBehaviour
{
    [SerializeField]
    private InputField _timerNameInput;
    [SerializeField]
    private Dropdown dropdownMenu;
    [SerializeField]
    private SimpleScrollSnap simpleScrollHours;
    [SerializeField]
    private SimpleScrollSnap simpleScrollMinutes;
    private Toggle[] weekDayToggles;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
