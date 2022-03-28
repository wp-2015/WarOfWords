using System;

public abstract class Singleton_CSharp<T>
    where T : class, new()
{
    private static T m_Instance;
    private static object lockHelper = new object();

    public static T Instance
    {
        get
        {
            if (m_Instance == null)
            {
                lock (lockHelper)
                {
                    if (m_Instance == null)
                    {
                        m_Instance = new T();
                    }
                }
            }
            return m_Instance;
        }
    }
}

