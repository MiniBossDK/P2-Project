using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadTesting : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(TestNav);
    }

    private void TestNav()
    {
        SceneChangeManager.LoadScene("AddRoomTest");
    }
    
}
