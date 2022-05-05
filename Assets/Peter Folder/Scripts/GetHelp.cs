using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetHelp : MonoBehaviour
{
    [SerializeField] Button getHelp, news, privacy, quit;

    void Start()
    {
        getHelp.onClick.AddListener(GetHlep);
        news.onClick.AddListener(NewsOpener);
        privacy.onClick.AddListener(PrivacyUnLink);
        quit.onClick.AddListener(Quitter);
    }

    private void GetHlep()
    {
        SceneManager.LoadScene("FaQ Fane");
    }

    private void NewsOpener()
    {
        Application.OpenURL("http://sgarmaturen.sg-as.com/dk/residential-dk/?page=1");
    }

    private void PrivacyUnLink()
    {
        Application.OpenURL("https://www.sg-as.com/information-protection-personal-data?fbclid=IwAR1rnIiri2sHMrQvV86quELy7p_os-uQqiQuZCjF62hzKFB2UyCmRC1yx_s");
    }

    private void Quitter()
    {
        Application.Quit();
    }
}
