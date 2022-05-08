using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
            var sceneObject = Instantiate(scenePrefab, sceneContainer.transform);
            sceneObject.transform.SetAsFirstSibling();
            var sceneName = sceneObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            sceneName.text = scene.SceneName;
        }
    }
}
