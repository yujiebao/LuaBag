using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//继承了MonoBehaviour的单例模式  需要我们自己保证他的唯一性
public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T GetInstance()
    {
        return instance;
    }

    protected virtual void Awake()
    {
        instance = this as T;
    }
}
