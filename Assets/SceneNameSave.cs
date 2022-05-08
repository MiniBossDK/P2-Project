using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneNameSave : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    
    private Button _button;
    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        PlayerPrefs.SetString("SceneName", inputField.text);
        SceneManager.LoadScene(9);
    }
}
