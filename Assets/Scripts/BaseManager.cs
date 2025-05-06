using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//单例模式基类  --减少单例模式代码
//不继承MonoBehaviour过场景不清除
public class BaseManager<T> where T : new()
{
   private static T instance;

   public static T GetInstance()
   {
       if(instance == null)
       {
           instance = new T();
       }
       return instance;
   }
}
