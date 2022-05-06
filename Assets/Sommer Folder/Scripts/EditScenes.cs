using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EditScenes : MonoBehaviour
{
    [SerializeField] private Button butt;

    public void Start()
    {
        butt.onClick.AddListener(LoadEditScene);
    }

    private void LoadEditScene()
    {
        //changementDeCadre.LoadNextScene();
    }
}
