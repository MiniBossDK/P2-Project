using System;
using UnityEngine;

[Serializable]
public struct Room
{
    public Room(string name, float lightTemperatureLevel, float lightLevel, int index)
    {
        Name = name;
        LightTemperatureLevel = lightTemperatureLevel;
        LightLevel = lightLevel;
        Index = index;
    }

    [SerializeField]
    public string Name;
    [SerializeField]
    public float LightTemperatureLevel;
    [SerializeField]
    public float LightLevel;
    [SerializeField]
    public int Index;
}
