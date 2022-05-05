using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class News : MonoBehaviour
{

    [SerializeField] Button news;

    // Start is called before the first frame update
    void Start()
    {
        news.onClick.AddListener(GetSomeNews);
    }

    private void GetSomeNews()
    {
        Application.OpenURL("http://sgarmaturen.sg-as.com/dk/residential-dk/?page=1");
    }
}
