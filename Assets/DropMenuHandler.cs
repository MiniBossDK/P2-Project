using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class DropMenuHandler : MonoBehaviour
{
    public string SelectedItem
    {
        get;
        private set;
    }
    private Button _dropdownMenu;
    [SerializeField] private TextMeshProUGUI dropDownLabel;
    [SerializeField] private Image dropdownLogo;
    [SerializeField] private GameObject menusItems;

    private Sprite _upArrowIcon;
    private Sprite _downArrowIcon;

    private bool isShowingItems = true;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    void Start()
    {
        dropDownLabel = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _dropdownMenu = GetComponent<Button>();
        _dropdownMenu.onClick.AddListener(OnDropdownClicked);

        _downArrowIcon = Resources.Load<Sprite>("DropdownArrowDown");
        _upArrowIcon = Resources.Load<Sprite>("DropdownArrowUp");
        
        for (int i = 0; i < menusItems.transform.childCount; i++)
        {
            var btn = menusItems.transform.GetChild(i);
            menusItems.transform.GetChild(i).GetComponent<Button>().onClick.AddListener( () => OnSelectedItem(btn));
        }
    }

    private void OnDropdownClicked()
    {
        if (isShowingItems)
        {
            menusItems.SetActive(isShowingItems);
            isShowingItems = false;
            dropdownLogo.sprite = _upArrowIcon;
        }
        else
        {
            menusItems.SetActive(isShowingItems);
            isShowingItems = true;
            dropdownLogo.sprite = _downArrowIcon;
        }
    }
    private void OnSelectedItem(Transform o)
    {
        var textMesh = o.GetChild(0).GetComponent<TextMeshProUGUI>();
        var selectedText = textMesh.text;
        SelectedItem = o.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        var labelText = dropDownLabel.text;

        textMesh.text = labelText;

        dropDownLabel.text = selectedText;
    }
    
    
}
