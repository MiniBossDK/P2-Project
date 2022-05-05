using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EditBehaviour : MonoBehaviour
{
    public List<GameObject> rooms = new List<GameObject>();
    public List<GameObject> deleteLocation = new List<GameObject>();

    private string[] tags = new string[3] { "Room", "Scenes", "LightSources" };

    [SerializeField] private Button button;
    [SerializeField] Button minusButton;
    [SerializeField] private Button checkmark;
    [SerializeField] private TextMeshProUGUI title;
    private string originalTitle;





    void Start()
    {
        button.onClick.AddListener(EditRooms);
        originalTitle = title.text;
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
        checkmark.gameObject.SetActive(false);
        title.text = originalTitle;
    }

    private void EditRooms()
    {
        title.text = "Edit" + originalTitle;
        checkmark.gameObject.SetActive(true);
        checkmark.onClick.AddListener(KillMinusButton);
        foreach (string tag in tags)
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
