using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneCreateConfirm : MonoBehaviour
{
    private ScenesManager _scenesManager;
    private Button _button;

    [SerializeField] private GameObject roomContainer;

    private void Awake()
    {
        _scenesManager = new ScenesManager();
    }

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        for (int i = 1; i < roomContainer.transform.childCount - 1; i++)
        {
            string roomId = roomContainer.transform.GetChild(i).name;
            var roomUnfold = roomContainer.transform.GetChild(i).GetChild(0).GetComponent<SceneRoomUnfold>();
            if(!roomUnfold.lightSourceCheckIsOn) continue;
            var lightValue = roomUnfold.lightSliderValue;
            var temperatureValue = roomUnfold.lightSliderValue;
            _scenesManager.AddScene(new Scene(Guid.Parse(roomId), PlayerPrefs.GetString("SceneName"), new LightSource(Guid.NewGuid(), lightValue, temperatureValue)));
            
        }
        SceneManager.LoadScene(7);
    }
}
