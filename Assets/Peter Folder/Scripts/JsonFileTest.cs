using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class SaveRoom
{
    public string sceneName;
    public Vector3 buttonPosition;
    public static bool isLoaded = false;
}

public class JsonFileTest : MonoBehaviour
{
    public static JsonFileTest LoadJson;
    private string jsonSavePath;
    public SaveRoom saveRoom;

    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform canvas;
    [SerializeField] private Button saveButton;
    [SerializeField] private Button loadButton;
    [SerializeField] private string theName;
    public InputField inputField;

    void Awake()
    {
        if (LoadJson == null)
        {
            LoadJson = this;
        }
        else if (LoadJson != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        saveRoom = new SaveRoom();

        saveButton.onClick.AddListener(delegate { OnSaveButtonClick(); });
        loadButton.onClick.AddListener(delegate { OnLoadButtonClick(); });
        //LoadData ();
    }

    void Start()
    {
        jsonSavePath = Application.persistentDataPath + "/saveload.json";
    }

    public void OnSaveButtonClick()
    {
        SaveData();

        Debug.Log("Saved");
    }

    public void OnLoadButtonClick()
    {
        LoadData();
        prefab = Instantiate(prefab, new Vector3(360, 740, 0), Quaternion.identity) as GameObject;
        prefab.transform.SetParent(canvas.transform);

        Debug.Log("Loaded");
    }

    private void SaveData()
    {

        //Position
        saveRoom.buttonPosition = new Vector3(0,0,0);

        //Name value
        theName = inputField.text;
        PlayerPrefs.SetString("roomName", theName);

        string jsonData = JsonUtility.ToJson(saveRoom, true);
        File.WriteAllText(jsonSavePath, jsonData);
    }

    public void LoadData()
    {
        saveRoom = JsonUtility.FromJson<SaveRoom>(File.ReadAllText(Application.persistentDataPath + "/saveload.json"));

        Vector3 position;
        position = saveRoom.buttonPosition;
        transform.position = saveRoom.buttonPosition;

        //For testing purposes
        Debug.Log(transform.position);
    }
}