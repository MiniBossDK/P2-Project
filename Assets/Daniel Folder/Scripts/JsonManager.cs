using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonManager<T>
{

    private struct Data
    {
        public Data(List<T> data)
        {
            DataList = data;
        }

        public List<T> DataList;
    }

    private List<T> _data;

    private readonly string _fileName;

    private string Path => Application.dataPath + "/" + _fileName + ".json";

    protected JsonManager(string fileName)
    {
        _fileName = fileName;
        _data = LoadData();
        if (File.Exists(Path)) return;
        Stream cr = File.Create(Path);
        cr.Close();
    }
    
    protected void AddData(IEnumerable<T> data)
    {
        _data.AddRange(data);
        SaveData(_data);
    }
    
    protected void AddData(T data)
    {
        _data.Add(data);
        SaveData(_data);
    }
    
    protected void DeleteAllData(Predicate<T> filter)
    { 
        _data.RemoveAll(filter);
        SaveData(_data);
    }

    protected List<T> GetAllData()
    {
        _data = LoadData();
        return _data;
    }

    protected List<T> GetData(Predicate<T> filter)
    {
        _data = LoadData();
        return _data.FindAll(filter);
    }

    protected void DeleteAllData()
    {
        _data.Clear();
        SaveData(_data);
    }

    private void SaveData(List<T> data)
    {
        if (!File.Exists(Path))
        {
            Stream cr = File.Create(Path);
            cr.Close();
        }

        var jsonData = JsonUtility.ToJson(new Data(data), true);

        _data = data;
        
        File.WriteAllText(Path, jsonData);
    }

    private List<T> LoadData()
    {
        if (File.Exists(Path)) return JsonUtility.FromJson<Data>(File.ReadAllText(Path)).DataList ?? new List<T>();
        Stream cr = File.Create(Path);
        cr.Close();
        return new List<T>();
    }
}
