using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditRoomButton : MonoBehaviour
{
    [SerializeField] private Button editButton;
    public bool isOn = false;
    // Start is called before the first frame update
    void Start()
    {
        editButton.onClick.AddListener(SetState);
    }

    public void SetState()
    {
        if (isOn)
        {
            isOn = false;
        } else if (!isOn)
        {
            isOn = true;
        }
    }
}
