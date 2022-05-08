using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneRoomUnfold : MonoBehaviour
{
    [SerializeField]
    private GameObject sceneLightSourcePrefab;
    
    private Button _button;
    private Image dropDownIcon;

    public float lightSliderValue = 0;
    public float temperatureSliderValue = 0;

    public bool lightSourceCheckIsOn;
    
    private Sprite dropDownArrowUp;
    private Sprite dropDownArrowDown;
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
        dropDownArrowUp = Resources.Load<Sprite>("DropDownArrowUp");
        dropDownArrowDown = Resources.Load<Sprite>("DropdownArrowDown");
        
        dropDownIcon = transform.GetChild(1).GetChild(0).GetComponent<Image>();
    }

    private void OnClick()
    {
        var parent = transform.parent;
        var lightSource = parent.GetChild(1).gameObject;
        var lightSourceScript = lightSource.GetComponent<SceneLightSourceHandler>();

        lightSourceCheckIsOn = lightSourceScript.isOn;
        
        var sliders = parent.GetChild(2).gameObject;

        lightSliderValue = sliders.transform.GetChild(0).GetComponent<Slider>().value;
        temperatureSliderValue = sliders.transform.GetChild(1).GetComponent<Slider>().value;
        
        dropDownIcon.sprite = (dropDownIcon.sprite == dropDownArrowDown) ? dropDownArrowUp : dropDownArrowDown;
        if (dropDownIcon.sprite == dropDownArrowUp)
        {
            lightSource.SetActive(true);
            if(lightSourceScript.isOn) sliders.SetActive(true);
        }
        else
        {
            lightSource.SetActive(false);
            sliders.SetActive(false);

        }
    }
}
