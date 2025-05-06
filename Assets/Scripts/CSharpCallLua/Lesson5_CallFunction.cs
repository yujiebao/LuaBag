using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Events;
using XLua;

[CSharpCallLua]
delegate void LuaFunction1();//无参无返回
//该特性是在Lua的命名空间  需要再XLua组件中生成代码
[CSharpCallLua]
delegate int LuaFunction2(int a );  //有参有返回 
[CSharpCallLua]
public delegate int LuaFunction3(int a ,out int b,out int c,out int d);
[CSharpCallLua]
public delegate int LuaFunction3_1(int a , ref int b,ref int c,ref int d);
[CSharpCallLua]delegate void LuaFunction4(params int[] arr);  //变长参数的类型是根据实际情况来定的  

public class Lesson5_CallFunction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager luaManager =  LuaManager.GetInstance();
        luaManager.Init();
        luaManager.DoFile("Main");

        //无参无返回
        //委托
        LuaFunction1 call = luaManager.Global.Get<LuaFunction1>("testFunc");
        call();
        UnityAction call_1 = luaManager.Global.Get<UnityAction>("testFunc");
        call_1();
        Action call_2 = luaManager.Global.Get<Action>("testFunc");
        call_2();
        //Lua提供的一种获取函数的方式 少用
        LuaFunction call_3 = luaManager.Global.Get<LuaFunction>("testFunc");
        call_3.Call();

        //有参有返回
        LuaFunction2 call2 = luaManager.Global.Get<LuaFunction2>("testFunc2");
        Debug.Log(call2(1));
        Func<int,int> call2_1 = luaManager.Global.Get<Func<int,int>>("testFunc2");  //C#
        Debug.Log(call2_1(1));
        //XLua提供
        LuaFunction call2_2 = luaManager.Global.Get<LuaFunction>("testFunc2");
        Debug.Log(call2_2.Call(1)[0]);   //返回值是数字 只有一个返回值 所以应该是0

        //多返回值
        //使用out和ref来接收
        LuaFunction3 call3 = luaManager.Global.Get<LuaFunction3>("testFunc3");
        int a,b,c;
        Debug.Log(call3(1,out a,out b,out c));
        print(a+" "+b+" "+c);
        LuaFunction3_1 call3_1 = luaManager.Global.Get<LuaFunction3_1>("testFunc3");
        int a1= 1;
        int b1 = 2;
        int c1 = 3;
        Debug.Log(call3_1(1,ref a1,ref b1,ref c1));
        Debug.Log(a1+" "+b1+" "+c1);
        //XLua提供
        LuaFunction call3_2 = luaManager.Global.Get<LuaFunction>("testFunc3");
        object[] objs = call3_2.Call(1,2,3,4);
        for(int i = 0;i<objs.Length;i++)
        {
            Debug.Log(objs[i]);
        }

        //变长参数
        LuaFunction4 call4 = luaManager.Global.Get<LuaFunction4>("testFunc4");
        call4(1,2,3,4,5,6,7,8,9,10);
        //XLua  引起更大销毁  unity不推荐
        LuaFunction call4_1 = luaManager.Global.Get<LuaFunction>("testFunc4");
        call4_1.Call("test",1,2,3,4,5,6,7,8,9,10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
