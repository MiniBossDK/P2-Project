using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FAQSGLogo : MonoBehaviour
{
    [SerializeField] Button button;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(Shift);
    }

    private void Shift()
    {
        SceneManager.LoadScene("TestUI");
    }
}
