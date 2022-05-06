using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneChangeManager
{
    public static int currentScene;

    public static void LoadPreviousScene()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene-1);
    }

    public static void LoadNextScene()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene +1);
    }

    public static void LoadHomePage()
    {
        SceneManager.LoadScene(0);
    }

}
