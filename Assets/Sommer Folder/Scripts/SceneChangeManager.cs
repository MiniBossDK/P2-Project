using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public int currentScene;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(currentScene-1);
    }
}
