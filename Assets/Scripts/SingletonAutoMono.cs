using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//自动的单例模式
//直接添加一个对象添加脚本  不存在多个脚本的问题
//推荐使用
public class SingletoAutonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T GetInstance()
    {
        if (instance == null)
       {
           GameObject obj = new GameObject();
           obj.name = typeof(T).ToString();
           DontDestroyOnLoad(obj);
           instance = obj.AddComponent<T>();
       }
        return instance;
    }

}
