using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3_LuaMgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //参数化解析器    
        LuaManager luaManager =  LuaManager.GetInstance();
        luaManager.Init();
        // luaManager.DoString("require('test')");
        luaManager.DoFile("test");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
