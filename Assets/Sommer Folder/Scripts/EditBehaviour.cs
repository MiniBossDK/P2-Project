using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EditBehaviour : MonoBehaviour
{
    public delegate void DeleteRoomEvent();

    public event DeleteRoomEvent OnDeleteRoomEvent;

    private string[] tags = new string[3] { "Room", "Scenes", "LightSources" };

    [SerializeField] private Button button;
    [SerializeField] Button minusButton;
    [SerializeField] private Button checkmark;
    [SerializeField] private TextMeshProUGUI title;
    private string originalTitle;
    public GameObject popUpWindow;
    public GameObject AddRoom;

    void Start()
    {
        button.onClick.AddListener(EditRooms);
        originalTitle = title.text;
        checkmark.gameObject.SetActive(false);
    }

    private void KillMinusButton()
    {
        GameObject[] deleteButtons = GameObject.FindGameObjectsWithTag("MinusButton");
        foreach (GameObject deleteButton in deleteButtons)
        {
            Destroy(deleteButton);
        }
        popUpWindow.SetActive(false);
        checkmark.gameObject.SetActive(false);
        AddRoom.SetActive(true);
        title.text = originalTitle;
    }

    private void EditRooms()
    {
        AddRoom.SetActive(false);
        title.text = "Edit " + originalTitle;
        checkmark.gameObject.SetActive(true);
        checkmark.onClick.AddListener(KillMinusButton);

        foreach (GameObject dl in GameObject.FindGameObjectsWithTag("DeleteLocation"))
        {
            Instantiate(minusButton, dl.transform);
        }
    }
}
