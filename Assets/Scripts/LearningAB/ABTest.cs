using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //加载路径
        AssetBundle ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + "Prefabs");
        print(ab);
        //加载资源
        //使用泛型 或者 Type指定类型  --区分同名不同类型
        // GameObject go = ab.LoadAsset<GameObject>("Cube");
        GameObject go = ab.LoadAsset("Cube",typeof(GameObject)) as GameObject;
        Instantiate(go);  

        //AB包不能多次加载 会报错
        GameObject Sphere = ab.LoadAsset<GameObject>("Sphere");
        Instantiate(Sphere);
        // StartCoroutine(LoadABRes("materials","New Material"));

        //加载依赖包
        //通过主包加载依赖包
        //加载主包包
        AssetBundle main = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + "StandaloneWindows");
        //加载主包中的固定文件
        AssetBundleManifest assetBundleManifest = main.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        //从固定文件中  得到依赖信息
        string[] strs = assetBundleManifest.GetAllDependencies("prefabs");
        for (int i = 0; i < strs.Length; i++)
        {
             AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + strs[i]);
        }
    }

    // IEnumerator LoadABRes(string ABName , string ResName)
    // {
    //     //加载AB包
    //     AssetBundleCreateRequest assetBundleRequest = AssetBundle.LoadFromFileAsync(Application.streamingAssetsPath + "/" + ABName);
    //     yield return assetBundleRequest;
    //     //加载资源
    //     // AssetBundleRequest abq = assetBundleRequest.assetBundle.LoadAssetAsync<Material>(ResName);    materials只需要加载包就可以了 引用建立
    //     // yield return abq;
    // }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // 卸载所有加载的AB包 参数为ture 会把通过AB包加载的资源也卸载了
            AssetBundle.UnloadAllAssetBundles(false);
        }
    }

}
