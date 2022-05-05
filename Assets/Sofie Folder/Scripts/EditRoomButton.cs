using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditRoomButton : MonoBehaviour
{
    [SerializeField] private Button editButton;
    [SerializeField] private List<Button> deleteButtons = new List<Button>();
    public bool isOn = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetState()
    {
        if (isOn)
        {
            foreach(Button deleteButton in deleteButtons)
            {
                deleteButton.gameObject.SetActive(false);
            }
            isOn = false;
        } else if (!isOn)
        {
            foreach (Button deleteButton in deleteButtons)
            {
                deleteButton.gameObject.SetActive(true);
            }
            isOn = true;
        }
    }

}
