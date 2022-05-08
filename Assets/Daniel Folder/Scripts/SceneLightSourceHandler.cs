using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneLightSourceHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject _slidersPrefab;
    
    private Image _checkBox;
    private Button _button;

    private Sprite _checkBoxChecked;
    private Sprite _checkBoxUnchecked;

    public bool isOn;

    public SceneLightSourceHandler(GameObject slidersPrefab)
    {
        _slidersPrefab = slidersPrefab;
    }

    private void Start()
    {
        _button = GetComponent<Button>();
        _checkBox = transform.GetChild(1).GetChild(0).GetComponent<Image>();
        _checkBoxChecked = Resources.Load<Sprite>("CheckedCircle");
        _checkBoxUnchecked = Resources.Load<Sprite>("NonCheckedCircle");
        
        _button.onClick.AddListener(OnClicked);
    }

    private void OnClicked()
    {
        var sliders = transform.parent.GetChild(2).gameObject;
        _checkBox.sprite = (_checkBox.sprite == _checkBoxChecked) ? _checkBoxUnchecked : _checkBoxChecked;
        if (_checkBox.sprite == _checkBoxChecked)
        {
            isOn = true;
            sliders.SetActive(true);
        }
        else
        {
            isOn = false;
            sliders.SetActive(false);
        }
        
    }
}
