using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteRoom : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject deleteMessage;
    [SerializeField] private Button deleteButton;
    [SerializeField] private Button cancelButton;
    [SerializeField] private EditBehaviour editBehaviour;
    private RoomManager roomManager;
    //  [SerializeField]private EditBehaviour editBehaviour;
    // Start is called before the first frame update
    private void Awake()
    {
        roomManager = new RoomManager();
    }

    void Start()
    {
        editBehaviour = GameObject.FindGameObjectWithTag("Manager").GetComponent<EditBehaviour>();
        deleteMessage = editBehaviour.popUpWindow;
        button.onClick.AddListener(OpenDeleteMessage); ;
    }


    private void OpenDeleteMessage()
    {
       // deleteMessage.SetActive(true);
        //deleteButton = GameObject.FindGameObjectWithTag("DeleteButton").GetComponent<Button>();
        //cancelButton = GameObject.FindGameObjectWithTag("CancelButton").GetComponent<Button>();
        //deleteButton.onClick.AddListener(KillRoom);
        //cancelButton.onClick.AddListener(CloseDeleteMessage);
        button.onClick.AddListener(KillRoom);

    }

    private void CloseDeleteMessage()
    {
        deleteMessage.SetActive(false);
        
    }
    public void KillRoom()
    {
        Destroy(button.transform.parent.parent.parent.parent.gameObject);
        string id = button.transform.parent.parent.parent.parent.gameObject.name;
        roomManager.DeleteRoom(room => room.ID == id);
        CloseDeleteMessage();
    }

}
