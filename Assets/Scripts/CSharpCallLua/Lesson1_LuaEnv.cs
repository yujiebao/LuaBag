using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
public class Lesson1_LuaEnv : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //XLua解析器  能够让我们在Unity中执行XLua
        LuaEnv env = new LuaEnv();

        //执行Lua语言
        env.DoString("print('Hello World')","错误了");//第二个参数--执行出错时打印
        env.DoString("require('test')");

        //帮助我们清楚Lua中我们没有手动释放的对象 垃圾回收
        //帧更新中定时执行 或者 切场景时执行
        // env.Tick();

        //销毁LuaEnv
        env.Dispose();
    }

  

    // Update is called once per frame
    void Update()
    {
        
    }
}
