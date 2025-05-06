using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestABMgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // GameObject gameObject =  ABMgr.GetInstance().LoadRes("prefabs","Cube") as GameObject;
        // gameObject = ABMgr.GetInstance().LoadRes("prefabs","Cube",typeof(GameObject)) as GameObject;
        // gameObject = ABMgr.GetInstance().LoadRes<GameObject>("prefabs","Cube");

        ABMgr.GetInstance().LoadResAsync("prefabs","Cube",(obj)=>{
                (obj as GameObject).transform.position = Vector3.up;
        });
        ABMgr.GetInstance().LoadResAsync("prefabs","Cube",typeof(GameObject),(obj)=>{
                (obj as GameObject).transform.position = Vector3.right;
        });
        ABMgr.GetInstance().LoadResAsync<GameObject>("prefabs","Cube",(obj)=>{
               obj.transform.position = Vector3.forward;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
