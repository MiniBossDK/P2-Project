using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteRoom : MonoBehaviour
{
    [SerializeField] private EditRoomButton editRoomButton;
    [SerializeField] private List<Button> button = new List<Button>();
    [SerializeField] private GameObject deleteMessage;
    [SerializeField] private Button deleteButton;
    [SerializeField] private Button cancelButton;
    // Start is called before the first frame update
    void Start()
    {
        editRoomButton = GameObject.FindObjectOfType<EditRoomButton>();
        //button.AddRange(GameObject.FindGameObjectsWithTag("DeleteButton"));
        deleteMessage.SetActive(false);
        cancelButton.onClick.AddListener(CloseDeleteMessage);
        DeleteRoomsInScene();
    }

    private void Update()
    {
        
    }
    private void CheckIfOn()
    {
        if (editRoomButton.isOn)
        {
            cancelButton.onClick.AddListener(CloseDeleteMessage);
            DeleteRoomsInScene();
        }
    }

    private void DeleteRoomsInScene()
    {
        foreach (Button button in button)
        {
            button.onClick.AddListener((delegate { OpenDeleteMessage(button); })); ;
        }
    }

    private void OpenDeleteMessage(Button roomDeleteButton)
    {
        deleteMessage.SetActive(true);
        deleteButton.onClick.AddListener((delegate { KillRoom(roomDeleteButton.transform.parent.parent.parent.parent.gameObject); }));
    }

    private void CloseDeleteMessage()
    {
        deleteMessage.SetActive(false);
    }
    public void KillRoom(GameObject obj)
    {
        Destroy(obj);
        CloseDeleteMessage();
    }

}
