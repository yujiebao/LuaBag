using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using XLua.LuaDLL;

/// <summary>
/// Lua无法直接访问C# 一定是先从C#调用Lua脚本后
/// 才把核心逻辑交给Lua脚本处理
/// </summary> <summary>
/// 
/// </summary>
public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager luaMgr = LuaManager.GetInstance();
        luaMgr.Init();
        luaMgr.DoFile("Main");
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
