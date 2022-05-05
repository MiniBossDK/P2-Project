using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextEditor : MonoBehaviour
{
    
    public TextMeshProUGUI textTop;
    public TextMeshProUGUI textBottom;
    [SerializeField]
    private TMP_InputField inputfield;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetName()
    {
        textTop.text = inputfield.text;
        textBottom.text = inputfield.text;
    }
}
