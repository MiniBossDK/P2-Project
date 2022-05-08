using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class SliderValuePresenter : MonoBehaviour
{
    private RoomManager _roomManager;
    [SerializeField] private GameObject valuePresenterContainer;
    [SerializeField] private TextMeshProUGUI valuePresenter;
    private Slider _slider;
    private InputManager _inputManager;

    private string _containerId;

    private bool _isTouching;
    private bool _isUsingSlider;

    private bool IsChangingSlider => _isTouching && _isUsingSlider;

    private void Awake()
    {
        _roomManager = new RoomManager();
        _inputManager = InputManager.Instance;
        _inputManager.input.TouchControls.TouchPress.started += OnTouch;
        _inputManager.input.TouchControls.TouchPress.canceled += OnTouch;
    }
    
    /*
    private void OnDisable()
    {
        _inputManager.input.TouchControls.TouchPress.started -= OnTouch;
        _inputManager.input.TouchControls.TouchPress.canceled -= OnTouch;
    }
    */

    private void Start()
    {
        _containerId = transform.parent.parent.name;
        _slider = GetComponent<Slider>();
        
        foreach (var room in _roomManager.GetAllRooms())
        {
            if (_containerId == room.ID)
            { 
                _slider.value = room.LightLevel;
            }
           
        }
        _slider.onValueChanged.AddListener(OnSliderChanged);
    }

    private void OnTouch(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            _isTouching = true;
        }

        if (ctx.canceled)
        {
            _isTouching = false;
            _isUsingSlider = false;
            valuePresenterContainer.SetActive(false);
            var rooms = _roomManager.GetAllRooms();
            foreach (var room in rooms)
            {
                if (_containerId == room.ID)
                {
                    rooms.Remove(room);
                    _roomManager.AddRoom(new Room(Guid.Parse(room.ID), room.Name, room.RoomIconPath, room.LightTemperatureLevel, _slider.value, room.Index));
                    break;
                }
            }
        }
    }

    private void OnSliderChanged(float value)
    {
        _isUsingSlider = true;
        if (IsChangingSlider)
        {
            valuePresenter.text = Mathf.CeilToInt(value * 100f).ToString();
            valuePresenterContainer.SetActive(true);
        }
    }
}
