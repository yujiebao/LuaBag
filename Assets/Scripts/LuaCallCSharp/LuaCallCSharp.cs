using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XLua;

#region 第一次课 调用类函数
public class Test{
    public void Speak(string str)
    {
        Debug.Log("Test"+str);
    }
}

namespace SelfSpace{
    public class Test2{
        public void Speak(string str)
        {
            Debug.Log("Test2"+str);
        }
    }
}

#endregion

#region 第二次课 调用枚举类型
/// <summary>
/// 自定义测试枚举
/// </summary> <summary>
public enum E_MyEnum
{
    Idle,
    Move,
    Attack,
    Die
}
#endregion

#region 第三次课 调用数组 字典
public class Lesson3
{
    public int[] array = new int[5]{1,2,3,4,5};

    public List<int> list = new List<int>();
    public Dictionary<int,string> dict = new Dictionary<int, string>();
}
#endregion

#region 第四次课 拓展方法
public class Lesson4
{
    public string name = "Lesson4";

    public void Speak()
    {
        Debug.Log("Speak:"+name);
    }
    public static void Eat()
    {
        Debug.Log("吃东西");

    }
}

//想要在Lua中使用拓展方法 一定要在工具类前面加上特定
//建议 Lua中要使用的类 都加上该特性 可以提升性能
//如果不加该特性 除了拓展方法对应的类 其它类的使用 都不会报错
//但是Lua是通过反射的机制去调用的c#类 效率较低
[XLua.LuaCallCSharp]
public static class Tool
{
    public static void Move(this Lesson4 lesson4)
    {
        Debug.Log(lesson4.name + "移动");
    }
}
#endregion

#region 第五次课 ref和out
public class Lesson5
{
    public int RefFun(int a ,ref int b,ref int c,int d)
    {
        b = a + d;
        c = a - d;
        return b*c;
    }

    public int OutFun(int a,out int b,out int c,int d)
    {
        b = a + d;
        c = a - d;
        return b*c;
    }

    public int RefOutFun(int a,ref int b,out int c,int d)
    {
        b = a + d;
        c = a - d;
        return b*c;
    }
}
#endregion

#region 第六次课 函数重载
public class Lesson6
{
    public int Calc()
    {
        return 1;
    }

    public int Calc(int a , int b)
    {
        return a + b;
    }

    public int Calc(int a)
    {
        return a;
    }

    public float Calc(float a , float b)
    {
        return a + b ;
    }
    
}
#endregion

#region 第七次课 委托和事件
[XLua.LuaCallCSharp]
public class Lesson7
{
    public UnityAction del;
    // public UnityEvent eventAction;
    public event UnityAction eventAction;

    public void DoEvent()    //事件只能内部调用
    {
        eventAction?.Invoke();
    }

    public void ClearEvent()
    {
        eventAction = null;
    }
}
#endregion

#region 第八次课 二维数组的遍历
public class Lesson8
{
    public int[,] array = new int[3,4]{
        {1,2,3,4},
        {5,6,7,8},
        {9,10,11,12}
    };
}
#endregion

#region 第九次课 拓展方法
[XLua.LuaCallCSharp]
public static class Lesson9
{
    public static bool IsNull(this UnityEngine.Object obj)
    {
        return obj == null;
    }
}
#endregion

#region 第十次课 系统类型加特性
public static class Lesson10
{
    [CSharpCallLua]   //批量添加特性
    public static List<Type> csharpCallLuaList = new List<Type>()
    {
         typeof(UnityAction<float>),
    };

    [LuaCallCSharp]
    public static List<Type> luaCallCSharpList = new List<Type>()
    {
        typeof(UnityAction<float>),
    };
}
#endregion
#region 第十二次课  调用泛型方法
public class Lesson12
{
    public interface ITest
    {
    }
    public class TestFather
    {
        
    }

    public class TestSon : TestFather,ITest
    {

    }

    public void TestFun<T>(T a,T b) where T : TestFather
    {
        Debug.Log("有参数的约束泛型方法");
    }

    public void TestFun2<T>(T a,T b) 
    {
        Debug.Log("有参数的无约束泛型方法");
    }

    public void TestFun3<T>() where T : TestFather
    {
        Debug.Log("无参数的约束泛型方法");
    }

    public void TestFun4<T>(T a) where T : ITest
    {
        Debug.Log("有参数的有接口约束泛型方法");
    }
    
}
#endregion
public class LuaCallCSharp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
