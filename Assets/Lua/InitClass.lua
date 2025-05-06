--常用别名都会在这里
--准备我们自己之前导入的脚本
--面向对象相关
require("Object")
--字符串拆分
require("SplitTools")
--Json解析
Json = require("JsonUtility")

--Unity相关
GameObject = CS.UnityEngine.GameObject
Resources = CS.UnityEngine.Resources
Transform = CS.UnityEngine.Transform
RectTransform = CS.UnityEngine.RectTransform
TextAsset = CS.UnityEngine.TextAsset
--图集对象
SpriteAtlas = CS.UnityEngine.U2D.SpriteAtlas

Vector2 = CS.UnityEngine.Vector2
Vector3 = CS.UnityEngine.Vector3

--UI相关
UI = CS.UnityEngine.UI
Image = UI.Image
TextMeshProUGUI = CS.TMPro.TextMeshProUGUI
Button = UI.Button
Toggle = UI.Toggle
ScrollRect = UI.ScrollRect
Canvas = GameObject.Find("Canvas").transform        --对于我们这个项目来说 是找一次就行
UIBehavior = CS.UnityEngine.EventSystems.UIBehaviour
--自己写的
ABMgr = CS.ABMgr.GetInstance()