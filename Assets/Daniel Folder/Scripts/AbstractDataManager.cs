using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public abstract class AbstractDataManager<T> : JsonManager<T>
{
    private List<T> dataList;
    public AbstractDataManager(string fileName) : base(fileName)
    {
        dataList = base.LoadData();
    }

    public void AddData(T data)
    {
        dataList.Add(data);
        base.SaveData(dataList);
    }

    public void DeleteData(Predicate<T> dataFilter)
    {
        dataList = base.LoadData();

        SaveData(dataList.FindAll(dataFilter));
    }

    public List<T> GetAllData(T data)
    {
        return dataList;
    }

    public void DeleteAllData()
    {
        dataList.Clear();
        base.SaveData(dataList);
    }
}
