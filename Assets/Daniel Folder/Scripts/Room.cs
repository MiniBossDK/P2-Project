using System;

[Serializable]
public class Room
{
    public Room(string name, float lightTemperatureLevel, float lightLevel, int index)
    {
        Name = name;
        LightTemperatureLevel = lightTemperatureLevel;
        LightLevel = lightLevel;
        Index = index;
    }

    public string Name;
    public float LightTemperatureLevel;
    public float LightLevel;
    public int Index;
}
