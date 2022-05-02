using System;
using UnityEngine;

[Serializable]
public struct Room
{
    public Room(Guid id, string name, float lightTemperatureLevel, float lightLevel, int index)
    {
        ID = id.ToString();
        Name = name;
        LightTemperatureLevel = lightTemperatureLevel;
        LightLevel = lightLevel;
        Index = index;
    }
    
    public Room(string name, float lightTemperatureLevel, float lightLevel, int index)
    {
        ID = Guid.NewGuid().ToString();
        Name = name;
        LightTemperatureLevel = lightTemperatureLevel;
        LightLevel = lightLevel;
        Index = index;
    }

    public string ID;
    public string Name;
    public float LightTemperatureLevel;
    public float LightLevel;
    public int Index;
}
