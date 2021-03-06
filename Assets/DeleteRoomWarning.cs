using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteRoomWarning : MonoBehaviour
{
    
    
    [SerializeField]
    private Button _button;

    private void Start()
    {
        _button.onClick.AddListener(OnCancelClicked);
    }

    private void OnCancelClicked()
    {
        gameObject.SetActive(false);
    }
}
