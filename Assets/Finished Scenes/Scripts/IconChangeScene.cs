using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconChangeScene : MonoBehaviour
{
    [SerializeField]
    private GameObject iconGroup;

    private void Awake()
    {
        for(int i = 0; i < iconGroup.transform.childCount; i++)
        {
            Sprite sprite = iconGroup.transform.GetChild(i).GetComponent<Image>().sprite;
            iconGroup.transform.GetChild(i).GetComponent<Button>().onClick.AddListener(() => NextScene(sprite));
        }
    }

    private void NextScene(Sprite sprite)
    {
        PlayerPrefs.SetString("RoomIcon", sprite.name);
        Debug.Log(PlayerPrefs.GetString("RoomIcon"));
        SceneChangeManager.LoadNextScene();
    }
}
