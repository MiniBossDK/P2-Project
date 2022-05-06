using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSceneChange : MonoBehaviour
{
    [SerializeField] private Button nextButton;

    private void Start()
    {
        nextButton.onClick.AddListener(ContinueButton);
    }

    private void ContinueButton()
    {
        SceneChangeManager.LoadNextScene();
    }
}
