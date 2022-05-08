using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SceneLoader : MonoBehaviour
{
    public int sceneIndex;
    private Button _button;
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ChangeToScene);
    }

    private void ChangeToScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
