using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTest : MonoBehaviour
{
    const string ACTION_SET_ALARM = "android.intent.action.SET_alarm";
    const string EXTRA_HOUR = "android.intent.extra.alarm.HOUR";
    const string EXTRA_MINUTES = "android.intent.extra.alarm.MINUTES";
    const string EXTRA_MESSAGE = "android.intent.extra.alarm.MESSAGE";

    private void OnClick()
    {
        CreateAlarm("message", 7, 02);
    }

    public void CreateAlarm(string message, int hour, int minute)
    {
        var intentAJO = new AndroidJavaObject(className: "android.content.Intent", ACTION_SET_ALARM);

        intentAJO
            .Call<AndroidJavaObject>("putExtra", EXTRA_MESSAGE, message)
            .Call<AndroidJavaObject>("putExtra", EXTRA_HOUR, hour)
            .Call<AndroidJavaObject>("putExtra", EXTRA_MINUTES, minute);

        GetUnityActivity().Call("startActivity", intentAJO);
    }

    AndroidJavaObject GetUnityActivity()
    {
        using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        }
    }

    //Skal tilføjes til AndroidManifest:
    //<uses-permission android:name="com.android.alarm.permission.SET_ALARM" />
}
