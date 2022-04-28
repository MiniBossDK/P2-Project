using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestInstantiation : MonoBehaviour
{
    public Text text;
    private string name;

    //Sets the text on the button equals to the user input that is stored into PlayerPrefs on awake.
    private void Awake()
    {
        text.text = GetString();
    }

    private string GetString()
    {
        name = PlayerPrefs.GetString("roomName");
        return name;
    }
}
