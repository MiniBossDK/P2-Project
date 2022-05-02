using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditBehaviour : MonoBehaviour
{
    public List<GameObject> rooms = new List<GameObject>();

    [SerializeField] private Button button;
    [SerializeField] Button minusButton;
    [SerializeField] GameObject deleteLocation;
    void Start()
    {
        button.onClick.AddListener(EditRooms);
        rooms.Add(GameObject.FindGameObjectWithTag("Room"));
    }

    private void EditRooms()
    {
        foreach(GameObject ro in rooms)
        {
            Instantiate(minusButton, deleteLocation.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
