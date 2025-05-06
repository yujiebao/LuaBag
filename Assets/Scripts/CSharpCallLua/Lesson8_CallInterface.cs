using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XLua;
//接口中不允许有成员变量
//我们用属性来接收类   
//接口拷贝是引用拷贝  接口数据改变lua的数据也会改变
[CSharpCallLua]
public interface CallInterface
{
    int testInt {get;set;}
    bool testBool {get;set;}
    string testString {get;set;}
    float testFloat {get;set;}
    UnityAction testfunc {get;set;}
}
public class Lesson8_CallInterface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager LuaMgr =  LuaManager.GetInstance();
        LuaMgr.Init();
        LuaMgr.DoFile("Main");

        CallInterface obj = LuaMgr.Global.Get<CallInterface>("testClass");
        Debug.Log("testInt:" + obj.testInt);
        Debug.Log("testBool:" + obj.testBool);
        Debug.Log("testString:" + obj.testString);
        Debug.Log("testFloat:" + obj.testFloat);
        obj.testfunc();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
