using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusButtonBehaviour : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject roomPrefab;
    //[SerializeField] private Text text;
    [SerializeField] private Transform canvas;
   // public string roomName;
    

    public List<string> test = new List<string>();

    void Start()
    {
        button.onClick.AddListener(NewRoom);
        test.Add("Tis");
        test.Add("Mis");
        test.Add("Pis");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void NewRoom()
    {
        roomPrefab = Instantiate(roomPrefab, new Vector3(360, 740, 0), Quaternion.identity) as GameObject;
        roomPrefab.transform.parent  = canvas.transform;
        SetString();
    }

    private void SetString()
    {
        PlayerPrefs.SetString("roomName", test[Random.Range(0, 2)]);
    }
}
