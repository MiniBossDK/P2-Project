using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusButtonBehaviour : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject roomPrefab;
    [SerializeField] private Transform canvas;

    //theName = the name which is stored into PlayerPrefs later on
    //inputField = the text input from the user
    public string theName;
    public GameObject inputField;


    void Start()
    {
        button.onClick.AddListener(StoreName);
    }

    //Instantiates the room prefab.
    private void NewRoom()
    {
        roomPrefab = Instantiate(roomPrefab, new Vector3(360, 740, 0), Quaternion.identity) as GameObject;
        roomPrefab.transform.SetParent(canvas.transform);
    }
    //Stores the input from the user into the PlayerPrefs, and runs the instantiation method afterwards - to avoid a null reference.
    public void StoreName()
    {
        theName = inputField.GetComponent<Text>().text;
        PlayerPrefs.SetString("roomName", theName);
        NewRoom();
    }
}
