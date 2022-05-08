using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSubMenus : MonoBehaviour
{
    private Button _button;
    
    private GameObject _subMenus;
    private Image dropDownIcon;

    private Sprite dropDownArrowDown;
    private Sprite dropDownArrowUp;
    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
        _subMenus = transform.GetChild(2).gameObject;

        dropDownIcon = transform.GetChild(0).GetChild(1).GetComponent<Image>();
        
        dropDownArrowDown = Resources.Load<Sprite>("DropdownArrowDown");
        dropDownArrowUp = Resources.Load<Sprite>("DropdownArrowUp");
    }

    private void OnClick()
    {
        dropDownIcon.sprite = (dropDownIcon.sprite == dropDownArrowUp) ? dropDownArrowDown : dropDownArrowUp;
        _subMenus.SetActive(dropDownIcon.sprite == dropDownArrowUp);
    }
}
