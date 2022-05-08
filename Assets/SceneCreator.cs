using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject scenePrefab;

    [SerializeField] private GameObject sceneContainer;
    private ScenesManager _scenesManager;

    private void Awake()
    {
        _scenesManager = new ScenesManager();
    }

    void Start()
    {
        foreach (var scene in _scenesManager.GetAllScenes())
        {
            //Instantiate(scenePrefab.gameObject, sceneContainer.gameObject);
        }
    }
}
