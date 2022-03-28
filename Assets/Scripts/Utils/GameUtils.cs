using System;
using UnityEngine;
using WP.OtherConfig;

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
    
    public static int GetStrengetStep(BodyConfig bc, int strength)
    {
        var lc = bc.lc;
        for (int i = 0; i < lc.Count; i++)
        {
            if (strength >= lc[i].Strength)
            {
                return i;
            }
        }
        return lc.Count - 1;
    }
}