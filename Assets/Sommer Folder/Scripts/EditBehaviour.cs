using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditBehaviour : MonoBehaviour
{
    public List<GameObject> rooms = new List<GameObject>();
    public List<GameObject> deleteLocation = new List<GameObject>();

    [SerializeField] private Button button;
    [SerializeField] Button minusButton;
    

         
void Start()
    {
        button.onClick.AddListener(EditRooms); 
    }

    private void Awake()
    {
        foreach (GameObject ro in GameObject.FindGameObjectsWithTag("Room"))
        {
            rooms.Add(ro);
        }

        foreach (GameObject dl in GameObject.FindGameObjectsWithTag("DeleteLocation"))
        {
            deleteLocation.Add(dl);
        }

    }

    private void EditRooms()
    {
        foreach (GameObject ro in rooms)
        {
            foreach(GameObject dl in deleteLocation)
            {
                Instantiate(minusButton,dl.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rooms.Count);
    }
}
