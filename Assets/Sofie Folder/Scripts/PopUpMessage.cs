using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PopupMessage : MonoBehaviour
{
    private InputManager inputManager;
    [SerializeField] private Image cancelImage;
    [SerializeField] private Image deleteImage;
    [SerializeField] private Button deleteButton;
    [SerializeField] private Button cancelButton;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
