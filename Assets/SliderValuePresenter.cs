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

    private void Awake()
    {
        _roomManager = new RoomManager();
        _inputManager = InputManager.Instance;

    }

    private void OnEnable()
    {
        _inputManager.input.TouchControls.TouchPress.started += OnTouch;
        _inputManager.input.TouchControls.TouchPress.canceled += OnTouch;
    }


    private void OnDisable()
    {
        _inputManager.input.TouchControls.TouchPress.started -= OnTouch;
        _inputManager.input.TouchControls.TouchPress.canceled -= OnTouch;
    }


    private void Start()
    {
        _containerId = transform.parent.parent.name;
        _slider = GetComponent<Slider>();

        _slider.onValueChanged.AddListener(OnSliderChanged);
    }

    private void OnTouch(InputAction.CallbackContext ctx)
    {
        if (ctx.canceled)
        {
            valuePresenterContainer.SetActive(false);
        }
    }

    private void OnSliderChanged(float value)
    {
        valuePresenter.text = ((int)(value * 100f)).ToString();
        valuePresenterContainer.SetActive(true);
    }
}
