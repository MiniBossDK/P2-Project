using System;
using System.Collections.Generic;

[Serializable]
public struct Scene
{

    public Scene(Guid roomId, string sceneName, LightSource lightSource)
    {
        RoomId = roomId.ToString();
        SceneName = sceneName;
        LightSource = lightSource;
    }
    
    public string RoomId;
    public string SceneName;
    public LightSource LightSource;
}
