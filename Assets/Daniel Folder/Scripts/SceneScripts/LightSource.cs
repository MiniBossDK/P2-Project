using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct LightSource
{

    public LightSource(Guid id, float lightLevel, float temperatureLevel)
    {
        ID = id.ToString();
        LightLevel = lightLevel;
        TemperatureLevel = temperatureLevel;
    }

    public string ID;
    public float LightLevel;
    public float TemperatureLevel;
}
