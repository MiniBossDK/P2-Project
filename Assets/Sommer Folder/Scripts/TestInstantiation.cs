using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestInstantiation : MonoBehaviour
{
    //public PlusButtonBehaviour plusButton = new PlusButtonBehaviour();
    public Text text;
    private string name;
    private void Awake()
    {
        text.text = GetString();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private string GetString()
    {
        name = PlayerPrefs.GetString("roomName");
        return name;
    }
}
