using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject canvas;
    private GameObject an;
    Transform local;
    // Start is called before the first frame update
    void Start()
    {
        ABMgr a = ABMgr.GetInstance();
        GameObject gameObject = a.LoadRes<GameObject>("ui","BagPanel");
        gameObject.transform.SetParent(canvas.transform,false);
        an = a.LoadRes<GameObject>("ui","ItemGrid");
        local = gameObject.transform.Find("svBag").Find("Viewport").Find("Content");
        an.transform.SetParent(local,false);
        an.transform.localPosition = Vector3.zero;
        print(an.transform.localPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
