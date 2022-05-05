using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditBehaviour : MonoBehaviour
{
    public List<GameObject> rooms = new List<GameObject>();
    public List<GameObject> deleteLocation = new List<GameObject>();

    private string[] tags = new string[3] { "Room", "Scenes", "LightSources" };

    [SerializeField] private Button button;
    [SerializeField] Button minusButton;
    [SerializeField] private Button checkmark;





    void Start()
    {
        button.onClick.AddListener(EditRooms);
        checkmark.onClick.AddListener(KillMinusButton);
    }

    private void Awake()
    {
        /*foreach (GameObject ro in GameObject.FindGameObjectsWithTag("Room"))
        {
            rooms.Add(ro);
        }

        foreach (GameObject dl in GameObject.FindGameObjectsWithTag("DeleteLocation"))
        {
            deleteLocation.Add(dl);
        }*/

    }

    private void KillMinusButton()
    {
        GameObject[] derSkalSlettes = GameObject.FindGameObjectsWithTag("Pis");
        foreach(GameObject drLicens in derSkalSlettes)
        {
            Destroy(drLicens);
            rooms.Clear();
            deleteLocation.Clear();
        }
    }

    private void EditRooms()
    {
        foreach(string tag in tags)
        {
            foreach (GameObject ro in GameObject.FindGameObjectsWithTag(tag))
            {
                rooms.Add(ro);
            }
        }

        foreach (GameObject dl in GameObject.FindGameObjectsWithTag("DeleteLocation"))
        {
            deleteLocation.Add(dl);
        }
        foreach (GameObject ro in rooms)
        {
            foreach (GameObject dl in deleteLocation)
                {
                Instantiate(minusButton, dl.transform);
                }
        }
    }
}
