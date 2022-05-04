using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightSourceHandler : MonoBehaviour
{
    private Button _lightSourceBtn;
    private Image _btnLogo;
    private bool _isOn = false;

    private void Awake()
    {
        _btnLogo = GetComponent<Image>();
        _lightSourceBtn = GetComponent<Button>();
        _lightSourceBtn.onClick.AddListener(OnClick);
        _isOn = (_btnLogo.sprite.name == "CheckedCircle");
        _btnLogo.sprite = Resources.Load<Sprite>(_isOn ? "CheckedCircle" : "NonCheckedCircle");
    }

    private void OnClick()
    {
        Debug.Log("yes");
        if (!_isOn)
        {
            _btnLogo.sprite = Resources.Load<Sprite>("CheckedCircle");
            _isOn = true;
        }
        else
        {
            _btnLogo.sprite = Resources.Load<Sprite>("NonCheckedCircle");
            _isOn = false;
        }
    }
}
