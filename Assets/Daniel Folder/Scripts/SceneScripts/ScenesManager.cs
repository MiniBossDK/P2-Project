using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesManager : JsonManager<Scene>
{
    public ScenesManager() : base("scenes")
    {
        
    }

    public void AddScene(Scene scene)
    {
        AddData(scene);
    }

    public void DeleteScene(Predicate<Scene> filter)
    {
        DeleteAllData(filter);
    }

    public List<Scene> GetAllScenes()
    {
        return GetAllData();
    }
}
