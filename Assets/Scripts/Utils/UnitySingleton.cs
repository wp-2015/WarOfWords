using System;
using UnityEngine;

public abstract class UnitySingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            lock(_lock)
            {
                if (instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));
                    if (instance == null)
                    {
                        instance = GameConst.GameLogicRootGameObject.AddComponent<T>();
                    }
                }
                return instance;
            }
        }
    }
    private static object _lock = new object();
 
}

