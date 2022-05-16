using System;
using UnityEngine;

public static class GameUtils
{
    public static void ShowLog(string log)
    {
        Debug.Log(log);
    }

    public static T LoadAsset<T>(string path) where T : UnityEngine.Object
    {
        return Resources.Load<T>(path);
    }

    public readonly static DateTime UTCStartTime = new DateTime(1970, 1, 1);
    public static long GetMillisecondsSince1970(DateTime endTime)
    {
        var ts = endTime.Subtract(UTCStartTime);
        return (long)ts.TotalMilliseconds;
    }

    public static long GetNowMilliseconds()
    {
        return GetMillisecondsSince1970(DateTime.Now);
    }
}