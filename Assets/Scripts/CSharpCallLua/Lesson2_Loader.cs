using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;
public class Lesson2_Loader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        LuaEnv env = new LuaEnv();

        //XLua提供的一个重定向的方法
        //允许我们自定义 加载 Lua文件的规则
        //当我们执行Lua语言 require 时 相当于执行一个lua脚本
        //它就会 执行 我们自定义传入的这个函数
        env.AddLoader(MyCustomLoader);
        env.DoString("require('test')");
    }

    //有自定义Loader优先执行自定义的Loader
    private byte[] MyCustomLoader(ref string name)  //自动传入require中的name
    {
        //传入的参数 是 require执行的lua脚本文件名
        //拼接一个Lua文件所在路径
        string path = Application.dataPath + "/Lua/" + name+".lua";  //不需要更改后缀为.txt了 已经通过File读取了字节码
        print("path="+path);
        
        //有路径 就去加载文件
        //File知识点 c#提供的文件读写的类
        if(File.Exists(path))
        {
            return File.ReadAllBytes(path);
        }
        else
        {
            print("文件不存在,文件名为:"+ name);
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


#region 补充
// 1.默认的从Resources加载Lua文件的缺点:
    // (1)打包后不能修改
    // (2)后缀为.txt  每次都要手动修改 麻烦
#endregion