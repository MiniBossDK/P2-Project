using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class URLOpen : MonoBehaviour
{
    //https://docs.unity3d.com/ScriptReference/Application.OpenURL.html

    public Button urlLink;
    public Button guideLink;
    public Button fAQLink;

    // Start is called before the first frame update
    void Start()
    {
        urlLink.onClick.AddListener(OpenAboutUsLink);
        guideLink.onClick.AddListener(OpenGuideLink);
        fAQLink.onClick.AddListener(OpenFAQLink);

    }

    private void OpenAboutUsLink()
    {
        Application.OpenURL("https://www.sg-as.com/da/kontakt-os");
    }

    private void OpenGuideLink()
    {
        Application.OpenURL("https://www.sg-as.com/da/sg-smart-app-guide");
    }

    private void OpenFAQLink()
    {
        Application.OpenURL("https://www.sg-as.com/da/sg-smart-faq");
    }

}
