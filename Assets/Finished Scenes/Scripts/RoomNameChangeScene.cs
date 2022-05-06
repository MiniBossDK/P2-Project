using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RoomNameChangeScene : MonoBehaviour
{
    [SerializeField] private TMP_InputField m_InputField;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(NameContinue);
    }

    private void NameContinue()
    {
        PlayerPrefs.SetString("RoomName", m_InputField.text);
        Debug.Log(PlayerPrefs.GetString("RoomName"));
        SceneChangeManager.LoadNextScene();

    }
}
