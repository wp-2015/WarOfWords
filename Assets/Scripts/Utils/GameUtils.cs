using System;
using UnityEngine;

public static class GameUtils
{
    public static void ShowLog(string log)
    {
        Debug.Log(log);
    }

    public static int GetNowMillisecond()
    {
        return DateTime.Now.Millisecond;
    }

    public static T LoadAsset<T>(string path) where T : UnityEngine.Object
    {
        return Resources.Load<T>(path);
    }
}