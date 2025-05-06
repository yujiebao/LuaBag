using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XLua.LuaDLL;

public class CallLuaClass
{
    //这个自定义中的变量可以更多或者更少  少了忽略 多了也不会赋值

    //在这个类中去声明成员变量
    //名字一定要和 Lua那边的一样
    //公共 私有和保护没办法赋值
    public int testInt;
    public bool testBool ;
    public string testString ;
    public float testFloat ;
    public CallLuaInClass testinClass;
    public UnityAction testfunc;
}

public class CallLuaInClass
{
    public int testinInt;
}
public class Lesson7_CallClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager LuaMgr =  LuaManager.GetInstance();
        LuaMgr.Init();
        LuaMgr.DoFile("Main");
        CallLuaClass obj = LuaMgr.Global.Get<CallLuaClass>("testClass");  //值拷贝  
        Debug.Log("testInt:" + obj.testInt);
        Debug.Log("testBool:" + obj.testBool);
        Debug.Log("testString:" + obj.testString);
        Debug.Log("testFloat:" + obj.testFloat);
        Debug.Log("testinInt:" + obj.testinClass.testinInt);
        obj.testfunc();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
