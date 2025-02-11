using System;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : class
{
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                Type type = typeof(T);

                GameObject go = new GameObject();
                go.name = type.Name;
                _instance = go.AddComponent(type) as T;
                DontDestroyOnLoad(go);
            }

            return _instance;
        }
    }

    private static T _instance;

    public virtual void Awake()
    {
        
    }

    public virtual void Start()
    {
        
    }

    public virtual void Update()
    {
        
    }
}
