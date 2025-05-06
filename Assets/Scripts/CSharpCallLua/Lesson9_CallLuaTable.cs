using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class Lesson9_CallLuaTable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager luaMgr = LuaManager.GetInstance();
        luaMgr.Init();
        luaMgr.DoFile("Main");
        //不建议使用LuaTable和LuaFunction 效率低
        //引用设置
        LuaTable luaTable = luaMgr.Global.Get<LuaTable>("testClass");  
        Debug.Log("testInt:" + luaTable.Get<int>("testInt"));
        Debug.Log("testBool:" + luaTable.Get<bool>("testBool"));
        Debug.Log("testString:" + luaTable.Get<string>("testString"));
        Debug.Log("testFloat:" + luaTable.Get<float>("testFloat"));
        luaTable.Get<LuaFunction>("testfunc").Call();
        // luaTable.Set("testString", "testString");    --引用设置
        luaTable.Dispose();   //记住需要释放   可能造成内存泄露
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
