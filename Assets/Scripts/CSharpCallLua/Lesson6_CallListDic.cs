using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson6_CallListDic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager luaMgr= LuaManager.GetInstance();
        luaMgr.Init();
        luaMgr.DoFile("Main");
        
        print("**************************************List*************************************");
        //浅拷贝
        //同一类型 List
        List<int> list = luaMgr.Global.Get<List<int>>("testList");
        foreach (var item in list)
        {
            Debug.Log("testList:" + item);
        }
        //不同类型
        List<object> list2 = luaMgr.Global.Get<List<object>>("testList2");
        foreach (var item in list2)
        {
            Debug.Log("testList2:" + item);
        }

        print("**************************************Dic*************************************");
        //浅拷贝
        //统一类型
        Dictionary<string,int> dic = luaMgr.Global.Get<Dictionary<string,int>>("testDic");
        foreach (var item in dic)   //遍历出来顺序有点不对
        {
            Debug.Log("testDic:" + item.Key + ":" + item.Value);  
        }
        //不统一类型
        Dictionary<object,object> dic2 = luaMgr.Global.Get<Dictionary<object,object>>("testDic2");
        foreach (var item in dic2)   //遍历出来顺序有点不对
        {
            Debug.Log("testDic:" + item.Key + ":" + item.Value);  
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
