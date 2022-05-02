using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class URLOpen : MonoBehaviour
{
    //From Unity Documentation
    public Button urlLink;

    // Start is called before the first frame update
    void Start()
    {
        urlLink.onClick.AddListener(OpenLink);
    }

    private void OpenLink()
    {
        Application.OpenURL("https://www.sg-as.com/da/kontakt-os");
    }

}
