using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonManager<T>
{

    private readonly string _fileName;

    protected string Path => Application.dataPath + "/" + _fileName + ".json";

    protected JsonManager(string fileName)
    {
        _fileName = fileName;
        if(!File.Exists(Path)) File.Create(Path);
    }

    protected void SaveData(List<T> data)
    {
        if (!File.Exists(Path)) File.Create(Path);

        var jsonData = JsonUtility.ToJson(data, true);
        Debug.Log(jsonData);
        File.WriteAllText(Path, jsonData);
    }

    protected List<T> LoadData()
    {
        if (File.Exists(Path))
        {
            if (File.ReadAllText(Path).Length == 0) return new List<T>();
            var data = JsonUtility.FromJson<List<T>>(File.ReadAllText(Path));
            return data ?? new List<T>();
        }
        File.Create(Path);
        return new List<T>();
    }
}
