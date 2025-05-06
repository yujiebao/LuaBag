using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson4_CallVar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager luaMgr = LuaManager.GetInstance();
        luaMgr.Init();
        luaMgr.DoFile("Main");

        //使用lua解析器luaenv中的Global属性
        //读
        int i = luaMgr.Global.Get<int>("testNumber");  //值拷贝，不会影响lua中的值
        Debug.Log("testNumber:" + i);
        float f = luaMgr.Global.Get<float>("testFloat");
        Debug.Log("testFloat:" + f);
        string s = luaMgr.Global.Get<string>("testString");
        Debug.Log("testString:" + s);
        bool b = luaMgr.Global.Get<bool>("testBool");
        Debug.Log("testBool:" + b);
        //写
        luaMgr.Global.Set("testNumber", 100);
        i = luaMgr.Global.Get<int>("testNumber");
        Debug.Log("testNumber:" + i);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
