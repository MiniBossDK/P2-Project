using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonManager<T>
{

    public struct Test
    {

        public Test(List<T> test)
        {
            TestList = test;
        }

        [SerializeField]
        public List<T> TestList;

    }



    private readonly string _fileName;

    protected string Path => Application.dataPath + "/" + _fileName + ".json";

    protected JsonManager(string fileName)
    {
        _fileName = fileName;
        if (!File.Exists(Path))
        {
            Stream cr = File.Create(Path);
            cr.Close();
        }

    }

    protected void SaveData(List<T> data)
    {
        if (!File.Exists(Path))
        {
            Stream cr = File.Create(Path);
            cr.Close();
        }

        var jsonData = JsonUtility.ToJson(new Test(data), true);
        Debug.Log(jsonData);
        File.WriteAllText(Path, jsonData);
    }

    protected List<T> LoadData()
    {
        if (!File.Exists(Path))
        {
            Stream cr = File.Create(Path);
            cr.Close();
        }
        return JsonUtility.FromJson<Test>(File.ReadAllText(Path)).TestList ?? new List<T>();
    }
}
